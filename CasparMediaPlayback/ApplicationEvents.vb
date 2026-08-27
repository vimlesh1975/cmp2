Imports System.IO
Imports CefSharp
Imports CefSharp.WinForms

Namespace My
    Partial Friend Class MyApplication
        Private Sub MyApplication_Startup(sender As Object, e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
            Try
                If Not Cef.IsInitialized Then
                    CefSharpSettings.SubprocessExitIfParentProcessClosed = True

                    Dim settings As New CefSettings()
                    Dim baseDir As String = AppDomain.CurrentDomain.BaseDirectory
                    Dim appDataRoot As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CasparMediaPlayback")
                    Dim appDataCef As String = Path.Combine(appDataRoot, "CefCache")
                    Dim appDataLocales As String = Path.Combine(appDataRoot, "locales")

                    If Not Directory.Exists(appDataCef) Then
                        Directory.CreateDirectory(appDataCef)
                    End If

                    ' Ensure appDataLocales directory and en-US.pak always exist
                    If Not Directory.Exists(appDataLocales) Then
                        Directory.CreateDirectory(appDataLocales)
                    End If

                    Dim appDataPak As String = Path.Combine(appDataLocales, "en-US.pak")
                    If Not File.Exists(appDataPak) Then
                        Try
                            Dim asm As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
                            For Each resName In asm.GetManifestResourceNames()
                                If resName.EndsWith("en-US.pak", StringComparison.OrdinalIgnoreCase) Then
                                    Using inStream As Stream = asm.GetManifestResourceStream(resName)
                                        If inStream IsNot Nothing Then
                                            Using outStream As New FileStream(appDataPak, FileMode.Create, FileAccess.Write)
                                                inStream.CopyTo(outStream)
                                            End Using
                                        End If
                                    End Using
                                    Exit For
                                End If
                            Next
                        Catch
                        End Try
                    End If

                    Dim baseLocales As String = Path.Combine(baseDir, "locales")
                    Dim localesDir As String = baseLocales
                    If Not Directory.Exists(baseLocales) OrElse Not File.Exists(Path.Combine(baseLocales, "en-US.pak")) Then
                        localesDir = appDataLocales
                    End If

                    settings.RootCachePath = appDataCef
                    settings.CachePath = Path.Combine(appDataCef, "Cache")
                    settings.BrowserSubprocessPath = Path.Combine(baseDir, "CefSharp.BrowserSubprocess.exe")
                    settings.LocalesDirPath = localesDir
                    settings.Locale = "en-US"
                    settings.ResourcesDirPath = baseDir
                    settings.MultiThreadedMessageLoop = True
                    settings.CefCommandLineArgs.Add("no-sandbox", "1")
                    settings.CefCommandLineArgs.Add("disable-gpu-shader-disk-cache", "1")
                    settings.CefCommandLineArgs.Add("locales-dir-path", localesDir)
                    settings.CefCommandLineArgs.Add("lang", "en-US")
                    Cef.Initialize(settings, performDependencyCheck:=False, browserProcessHandler:=Nothing)
                End If
            Catch ex As Exception
                System.Diagnostics.Debug.WriteLine("CEF initialization error: " & ex.Message)
            End Try
        End Sub
    End Class
End Namespace
