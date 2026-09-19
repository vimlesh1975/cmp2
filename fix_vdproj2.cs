using System;
using System.IO;
using System.Text.RegularExpressions;

public class Program {
    public static void Main() {
        string text = File.ReadAllText(@"CasparMediaPlaybackSetup\CasparMediaPlaybackSetup.vdproj");
        
        string pattern = @"\{9F6F8455-1EF1-4B85-886A-4223BCC8E7F7\}(:_[A-Z0-9]+)\s*\{\s*""AssemblyRegister""[\s\S]*?processorArchitecture=AMD64""\s*""ScatterAssemblies""\s*\{\s*""_[A-Z0-9]+""\s*\{\s*""Name""\s*=\s*""8:([^""]+)""\s*""Attributes""\s*=\s*""3:[0-9]+""\s*\}\s*\}\s*""SourcePath""\s*=\s*(""8:[^""]+"")\s*""TargetName""\s*=\s*""8:""";
        
        string newText = Regex.Replace(text, pattern, m => {
            string id = m.Groups[1].Value;
            string name = m.Groups[2].Value;
            string sourcePath = m.Groups[3].Value;
            
            return "{1E2AD844-6B49-4325-98BD-3BC607D6D632}" + id + "\n" +
                   "              {\n" +
                   "              \"SourcePath\" = " + sourcePath + "\n" +
                   "              \"TargetName\" = \"8:" + name + "\"";
        });
        
        File.WriteAllText(@"CasparMediaPlaybackSetup\CasparMediaPlaybackSetup.vdproj", newText);
    }
}
