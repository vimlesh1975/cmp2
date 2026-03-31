# CMP Refactor Tracker

This file tracks module-by-module cleanup/refactor work so we can keep momentum without losing context.

## Status Key

- `Done`: refactor completed and kept
- `In Progress`: currently being worked on
- `Pending`: not started yet
- `Deferred`: intentionally postponed

## Completed

| Module | File | Status | Notes |
| --- | --- | --- | --- |
| `ucCG` | `CasparMediaPlayback/ucCG.vb` | Done | Logic refactored; visual redesign was reverted, original look kept. |
| `ucCG2` | `CasparMediaPlayback/ucCG2.vb` | Done | Logic refactored and duplication reduced. |
| `ucMixer` | `CasparMediaPlayback/ucMixer.vb` | Done | Mixer command sending, status reads, and XML save/load logic consolidated into shared helpers. |
| `ucMixernew` | `CasparMediaPlayback/ucMixernew.vb` | Done | Applied the same mixer helper consolidation as `ucMixer`, including XML settings and status-query cleanup. |
| `Form1` | `CasparMediaPlayback/Form1.vb` | Done | Composition element creation, playback, save/open, and loaded-media routing consolidated into reusable helpers. |
| `ucScroll` | `CasparMediaPlayback/ucScroll.vb` | Done | Scroll file I/O, row operations, selection toggles, color updates, and CG update helpers consolidated. |
| `ucBreakingNews` | `CasparMediaPlayback/ucBreakingNews.vb` | Done | Breaking-news file I/O, row operations, selection filters, and playback command helpers consolidated. |
| `ucTimers` | `CasparMediaPlayback/ucTimers.vb` | Done | Clock/timer template play, stop, clip-countdown update, and shared layer/template helpers consolidated. |
| `ucLogo` | `CasparMediaPlayback/ucLogo.vb` | Done | Logo data collection, opacity updates, file open/save, and shared layer/template helpers consolidated. |
| `UcCaption` | `CasparMediaPlayback/UcCaption.vb` | Done | Caption layer-address, fill updates, and resize synchronization centralized into small helpers. |
| `ucElement` | `CasparMediaPlayback/ucElement.vb` | Done | Media-source setup, layer command building, preview playback, fill updates, and YouTube/file helpers consolidated. |
| `ucHS` | `CasparMediaPlayback/ucHS.vb` | Done | Horizontal-scroll layer helpers, logo open/play/stop logic, color updates, and crawl data building consolidated. |
| `ucHS2` | `CasparMediaPlayback/ucHS2.vb` | Done | Secondary horizontal-scroll layer helpers, crawl text/data building, and color/font updates consolidated. |
| `ucHtmlScroller` | `CasparMediaPlayback/ucHtmlScroller.vb` | Done | HTML scroller call helpers, text preparation, start/cue routines, and repeated styling updates consolidated. |
| `ucNDISource` | `CasparMediaPlayback/ucNDISource.vb` | Done | NDI list fetching, response parsing, and dialog-close handling centralized into small helpers. |
| `ucCCTV` | `CasparMediaPlayback/ucCCTV.vb` | Done | CCTV RTSP command building, four-camera group playback, timer switching, and camera-list loading consolidated. |
| `ucdc` | `CasparMediaPlayback/ucdc.vb` | Done | Davis Cup animation routing, layer helpers, scorebug/service data building, and repeated template-play handlers consolidated. |
| `ucTemplate` | `CasparMediaPlayback/ucTemplate.vb` | Done | Template data building, CG command assembly, rundown file I/O, preview updates, and default loader-row setup consolidated. |
| `ucHtmlTemplate` | `CasparMediaPlayback/ucHtmlTemplate.vb` | Done | HTML play/call/stop helpers, rundown file I/O, update-row packing, and repeated mixer/layer command building consolidated. |
| `ucClipGrid` | `CasparMediaPlayback/ucClipGrid.vb` | Done | Clip-search table setup, result-row creation, progress updates, search matching, and slow-motion load routing consolidated. |
| `ucPlaylist` | `CasparMediaPlayback/ucPlaylist.vb` | Done | Playlist clip-tree building, clip-search table setup, search-result row creation, progress updates, and clip-grid play/cue command building consolidated. |
| `uc4ChannelPlayer` | `CasparMediaPlayback/uc4ChannelPlayer.vb` | Done | Four-player setup, window open, and shutdown actions consolidated into shared player-list helpers. |
| `uc4ChannelRecorderAndTrimmer` | `CasparMediaPlayback/uc4ChannelRecorderAndTrimmer.vb` | Done | Four-recorder setup, resize-helper initialization, and hide/OSC shutdown actions consolidated into shared recorder-list helpers. |
| `ucAMCPcommands` | `CasparMediaPlayback/ucAMCPcommands.vb` | Done | AMCP file open/save, reset, and command-send/response flow consolidated into shared helpers. |
| `ucCasparcgWindow` | `CasparMediaPlayback/ucCasparcgWindow.vb` | Done | Window parenting, seek/play/load command building, audio meter colors, and aspect-ratio layout updates consolidated into shared helpers. |
| `ucChannelInfo` | `CasparMediaPlayback/ucChannelInfo.vb` | Done | Channel-info XML read, row creation, version-specific parsing, and remove/stop actions consolidated into shared helpers. |
| `UcCommandScheduler` | `CasparMediaPlayback/UcCommandScheduler.vb` | Done | Scheduler grid setup, file open/save, reset/start/stop actions, and multi-command execution consolidated into shared helpers. |
| `UcCommandSchedulerDateWise` | `CasparMediaPlayback/UcCommandSchedulerDateWise.vb` | Done | Date-wise scheduler grid setup, file open/save, reset/start/stop actions, expired-row cleanup, and multi-command execution consolidated into shared helpers. |
| `ucCreatePng` | `CasparMediaPlayback/ucCreatePng.vb` | Done | Playlist insertion, Caspar image-add command sending, and generated image-name increment logic consolidated into shared helpers. |
| `ucCricket` | `CasparMediaPlayback/ucCricket.vb` | Done | Bottom-score HTML play/update handlers consolidated into shared helpers, including strike-marker handling and shared image/text updates. |
| `ucdBFSMeter` | `CasparMediaPlayback/ucdBFSMeter.vb` | Done | Meter polling, preview audio replay commands, pan-filter building, and 16-channel combo initialization consolidated into shared helpers. |
| `ucEyeDropper` | `CasparMediaPlayback/ucEyeDropper.vb` | Done | Load/init flow consolidated, cursor resource loading extracted, and repeated color-pick finish logic centralized into shared helpers. |
| `ucFaceBook` | `CasparMediaPlayback/ucFaceBook.vb` | Done | Facebook graph query building, row population, template play actions, and key-file token loading consolidated into shared helpers. |
| `ucFourChannelPreview` | `CasparMediaPlayback/ucFourChannelPreview.vb` | Done | Four preview-control multicast/channel setup consolidated into shared preview-list helpers. |
| `ucFullPageCaption` | `CasparMediaPlayback/ucFullPageCaption.vb` | Done | Full-page caption file/grid reset, template play, and HTML marquee/style update flows consolidated into shared helpers. |
| `ucHTML` | `CasparMediaPlayback/ucHTML.vb` | Done | HTML layer-address, play/call/mixer helpers, Facebook URL building, and YouTube/live-stream helper flows consolidated. |
| `ucHtmlScroller` | `CasparMediaPlayback/ucHtmlScroller.vb` | Done | Already refactored; retained shared scroller helper structure from earlier cleanup pass. |
| `ucImageScroll` | `CasparMediaPlayback/ucImageScroll.vb` | Done | Image-scroll layer addressing, play/call option toggles, and pause/resume command selection consolidated into shared helpers. |
| `ucMAM` | `CasparMediaPlayback/ucMAM.vb` | Done | Folder browsing, file-list population, command-window launching, bulk transcoder row selection, and EBU/FFmpeg utility command paths consolidated into shared helpers. |
| `ucMetadata` | `CasparMediaPlayback/ucMetadata.vb` | Done | FFmpeg metadata read/write command paths, grid reset/load, and metadata file save flow consolidated into shared helpers. |
| `ucMultiBulletScroll` | `CasparMediaPlayback/ucMultiBulletScroll.vb` | Done | Default icon setup, selection toggles, HTML scroller layer/call helpers, and marquee payload building consolidated into shared helpers. |
| `ucMySqlTest` | `CasparMediaPlayback/ucMySqlTest.vb` | Done | SQL/MySQL connection setup, adapter/command creation, HTML table generation, and color-picker updates consolidated into shared helpers. |
| `ucnewOffAirLogger` | `CasparMediaPlayback/ucnewOffAirLogger.vb` | Done | Recording path/command helpers, schedule file open/save, decklink/clock command building, and schedule-status updates consolidated into shared helpers. |
| `ucnewPreview` | `CasparMediaPlayback/ucnewPreview.vb` | Done | Preview stream URI building, keyed/plain preview command sending, and VLC preview playback consolidated into shared helpers. |
| `ucnewRecorder` | `CasparMediaPlayback/ucnewRecorder.vb` | Done | Recorder layer/path command building, recording-folder browsing, and repeated decklink/record/remove command text consolidated into shared helpers. |
| `ucnewSM2` | `CasparMediaPlayback/ucnewSM2.vb` | Done | Slow-motion layer addressing, speed command sending, and repeated load-seek command paths consolidated into shared helpers. |
| `ucnewTrimmer1` | `CasparMediaPlayback/ucnewTrimmer1.vb` | Done | Frame-to-time conversion, VLC seek stepping, and shared FFmpeg/BMX executable paths consolidated into small helpers. |
| `ucNG2015` | `CasparMediaPlayback/ucNG2015.vb` | Done | Scoped cleanup: repeated games-logo file pickers and shooting series button routing consolidated into shared helpers. |
| `ucOffAirLogger` | `CasparMediaPlayback/ucOffAirLogger.vb` | Done | Single-channel off-air logger initialization and shutdown flow consolidated into shared helper methods. |
| `ucOffAirLoggers` | `CasparMediaPlayback/ucOffAirLoggers.vb` | Done | Four-channel off-air logger setup and hide/cleanup flows consolidated into shared logger-list helpers. |
| `ucOneLiner` | `CasparMediaPlayback/ucOneLiner.vb` | Done | One-liner file dialog setup, selected-text routing, HTML layer/call sending, and repeated style update calls consolidated into shared helpers. |
| `ucOnLineCG` | `CasparMediaPlayback/ucOnLineCG.vb` | Done | Online CG host URLs and layer-address command building consolidated into shared helpers. |
| `ucOSC` | `CasparMediaPlayback/ucOSC.vb` | Done | OSC grid row population for message, bundle, and packet events consolidated into a shared row-update helper. |
| `ucOSD` | `CasparMediaPlayback/ucOSD.vb` | Done | OSD layer addressing, call sending, and selected-color routing consolidated into shared helpers. |
| `ucPlayers` | `CasparMediaPlayback/ucPlayers.vb` | Done | Player photo/flag picking and repeated Davis Cup template play flow consolidated into shared helpers. |
| `ucPlayFromAnyWhere` | `CasparMediaPlayback/ucPlayFromAnyWhere.vb` | Done | File-tree refresh, media-path normalization, and play/cue transport command building consolidated into shared helpers. |
| `UcPlaylistScheduler` | `CasparMediaPlayback/UcPlaylistScheduler.vb` | Done | Scheduler file open/save, next-run calculation, status updates, and scheduled playlist launch flow consolidated into shared helpers. |
| `ucPlaylistSetting` | `CasparMediaPlayback/ucPlaylistSetting.vb` | Done | Playlist channel/OSC selection, clip-source routing, and resize-mode mapping consolidated into shared helpers. |
| `ucPositionAndSize` | `CasparMediaPlayback/ucPositionAndSize.vb` | Done | Mixer fill layer addressing and value formatting consolidated into shared helpers. |
| `ucPowerPoint` | `CasparMediaPlayback/ucPowerPoint.vb` | Done | PowerPoint output command building, file watcher toggling, and Office document launch/panel attachment consolidated into shared helpers. |
| `ucPreview` | `CasparMediaPlayback/ucPreview.vb` | Done | Preview stream URL/command building, VLC playback startup, and repeated preview restart flow consolidated into shared helpers. |
| `ucQuiz` | `CasparMediaPlayback/ucQuiz.vb` | Done | Quiz layer offsets, encoded text building, file dialog setup, and row move/save/open helpers consolidated. |
| `ucRCCAutomation` | `CasparMediaPlayback/ucRCCAutomation.vb` | Done | RCC sample-flag loading and HTTP payload/upload flow consolidated into shared helpers. |
| `ucRccBall` | `CasparMediaPlayback/ucRccBall.vb` | Done | Ball output/device commands, mode switching, animation mixer helpers, and logo-picking helpers consolidated. |
| `ucRecorder` | `CasparMediaPlayback/ucRecorder.vb` | Done | Recorder layer commands, folder picker setup, and repeated VTR command sends consolidated into shared helpers. |
| `ucRemoteLogging` | `CasparMediaPlayback/ucRemoteLogging.vb` | Done | Remote logging connect/disconnect state handling and socket cleanup consolidated into shared helpers. |
| `ucRSS` | `CasparMediaPlayback/ucRSS.vb` | Done | RSS grid setup, select-all toggles, and scroll text/template data building consolidated into shared helpers. |
| `ucSceneScroller` | `CasparMediaPlayback/ucSceneScroller.vb` | Done | Scene scroller file dialog, text building, and repeated CG update calls consolidated into shared helpers. |
| `ucScreenConsumer` | `CasparMediaPlayback/ucScreenConsumer.vb` | Done | Screen consumer attach/detach flow consolidated into shared helpers. |
| `ucSG2016` | `CasparMediaPlayback/ucSG2016.vb` | Done | Games-logo picker and core animation mixer commands consolidated into shared helpers for safer reuse. |
| `ucSilenceDetector` | `CasparMediaPlayback/ucSilenceDetector.vb` | Done | Silence-level detection, reset flow, tone playback, and source-command sending consolidated into shared helpers. |
| `ucSlowMotion` | `CasparMediaPlayback/ucSlowMotion.vb` | Done | Slow-motion layer addressing and repeated call/seek command sending consolidated into shared helpers. |
| `ucSlowMotion21` | `CasparMediaPlayback/ucSlowMotion21.vb` | Done | Dual slow-motion player/recorder setup consolidated into configuration helpers. |
| `ucSMRecorder` | `CasparMediaPlayback/ucSMRecorder.vb` | Done | Recorder layer commands and folder picker setup consolidated into shared helpers. |
| `ucSongSubtitling` | `CasparMediaPlayback/ucSongSubtitling.vb` | Done | OSC address building, encoded subtitle text generation, and row-selection routing consolidated into shared helpers. |
| `ucSrtPlayer` | `CasparMediaPlayback/ucSrtPlayer.vb` | Done | SRT file dialog setup, encoded subtitle text generation, and bulk time shifting consolidated into shared helpers. |
| `ucStreaming` | `CasparMediaPlayback/ucStreaming.vb` | Done | Streaming target building and add/remove command assembly consolidated into shared helpers. |
| `ucStreamPlayer` | `CasparMediaPlayback/ucStreamPlayer.vb` | Done | External bin command launching and repeated NDI start/stop handling consolidated into shared helpers. |
| `ucSwfPlayer` | `CasparMediaPlayback/ucSwfPlayer.vb` | Done | SWF layer addressing and selected movie path handling consolidated into shared helpers. |
| `ucSystemAudio` | `CasparMediaPlayback/ucSystemAudio.vb` | Done | Per-channel add/remove audio toggles consolidated into a shared helper. |
| `frmfileinformation` | `CasparMediaPlayback/frmfileinformation.vb` | Done | Small shell cleanup: form positioning routed through a helper. |
| `frmMediaPlayer` | `CasparMediaPlayback/frmMediaPlayer.vb` | Done | Connection-state UI and server-path propagation consolidated into shared helpers. |
| `mdlcmp1` | `CasparMediaPlayback/mdlcmp1.vb` | Done | Shared fill-command calculation and external player launch argument building consolidated into reusable helpers. |
| `Settings` | `CasparMediaPlayback/My Project/Settings.settings` | Done | Settings file annotated for clearer long-term maintenance without changing values. |
| `ucTab` | `CasparMediaPlayback/ucTab.vb` | Done | Small shell cleanup: hide action routed through a helper for consistency with other docked utility modules. |
| `ucUdpChat` | `CasparMediaPlayback/ucUdpChat.vb` | Done | UDP send, receive-start, and receive-stop flows consolidated into shared helpers. |
| `ucUtility` | `CasparMediaPlayback/ucUtility.vb` | Done | Utility grid row setup and repeated explorer/notepad launch paths consolidated into shared helpers. |
| `ucTwitter` | `CasparMediaPlayback/ucTwitter.vb` | Done | Twitter HTML play flow and repeated grid reset logic consolidated into shared helpers. |
| `ucVideoPlayer` | `CasparMediaPlayback/ucVideoPlayer.vb` | Done | Clip-grid load/play command assembly consolidated into shared transport helpers. |
| `ucVlcStreamTester` | `CasparMediaPlayback/ucVlcStreamTester.vb` | Done | VLC preview stop/restart behavior consolidated into a shared helper. |
| `ucVTRController` | `CasparMediaPlayback/ucVTRController.vb` | Done | Repeated serial write calls and cue-command building consolidated into shared helpers. |
| `ucVS` | `CasparMediaPlayback/ucVS.vb` | Done | Vertical-scroll update and file-dialog setup consolidated into shared helpers. |
| `ucVS2` | `CasparMediaPlayback/ucVS2.vb` | Done | VS2 layer addressing, speed updates, and HTML call routing consolidated into shared helpers. |
| `ucWaterMarking` | `CasparMediaPlayback/ucWaterMarking.vb` | Done | Watermark mixer layer/value formatting consolidated into shared helpers. |
| `ucWeather` | `CasparMediaPlayback/ucWeather.vb` | Done | Weather icon data packing and open/save dialog setup consolidated into shared helpers. |
| `ucWebSocketServer` | `CasparMediaPlayback/ucWebSocketServer.vb` | Done | WebSocket status text, response payload building, and hidden-text updates consolidated into shared helpers. |
| `ucTemplatePlaylist` | `CasparMediaPlayback/ucTemplatePlaylist.vb` | Done | Rundown template-data packing and rundown file open/save flows consolidated into shared helpers. |
| `ucTranscodingProfile` | `CasparMediaPlayback/ucTranscodingProfile.vb` | Done | Codec-list loading and transcoding extension selection consolidated into shared helpers. |
| `ucTrimmer` | `CasparMediaPlayback/ucTrimmer.vb` | Done | Trim in/out command building and export save-dialog setup consolidated into shared helpers. |
| `ucTwoLiner` | `CasparMediaPlayback/ucTwoLiner.vb` | Done | Two-liner file dialogs, template data packing, and HTML call routing consolidated into shared helpers. |
| `ucVDCPController` | `CasparMediaPlayback/ucVDCPController.vb` | Done | Remote TCP state handling and repeated VDCP serial/cue command sending consolidated into shared helpers. |
| `ucVisionMixer` | `CasparMediaPlayback/ucVisionMixer.vb` | Done | Vision route/color command assembly consolidated into shared transition helpers. |
| `ucWeightLifting` | `CasparMediaPlayback/ucWeightLifting.vb` | Done | Weightlifting country-loader paths and shared game/event logo data consolidated into helpers. |
| `ucXdcamController` | `CasparMediaPlayback/ucXdcamController.vb` | Done | XDCAM clip-grid population consolidated into a shared helper. |
| `ucXdcamSoapClient` | `CasparMediaPlayback/ucXdcamSoapClient.vb` | Done | SOAP XDCAM clip-grid population consolidated into a shared helper. |
| `ucytlive` | `CasparMediaPlayback/ucytlive.vb` | Done | YouTube Live timezone-offset calculation and scheduler default-row setup consolidated into shared helpers. |

## Repository Cleanup

| Area | Status | Notes |
| --- | --- | --- |
| GitHub repo setup | Done | Project committed and pushed to `vimlesh1975/cmp2`. |
| Ignore rules | Done | Added ignores for `.vs`, `obj`, `.user`, logs, caches, and release output. |
| Release output tracking | Done | `CasparMediaPlayback/bin/x86/Release` removed from Git tracking. |
| Local dependency folder | Done | Added `CasparMediaPlayback/lib` and moved four project references off `bin/x86/Release`. |

## Next Suggested Modules

| Module | File | Status | Notes |
| --- | --- | --- | --- |
| `ucTicker1` | `CasparMediaPlayback/ucTicker1.vb` | Pending | Still worth a graphics-module cleanup pass similar to `ucScroll` and `ucTwoLiner`. |
| `frmROI` | `CasparMediaPlayback/frmROI.vb` | Pending | Small form, likely quick cleanup if needed. |
| `VolumeMixer` | `CasparMediaPlayback/VolumeMixer.vb` | Pending | Utility/helper file not yet tracked in the refactor pass. |

## How To Update

When a module is refactored:

1. Move it to `Completed`
2. Add a short note about what changed
3. Keep `Next Suggested Modules` focused on the next 3-5 realistic targets
