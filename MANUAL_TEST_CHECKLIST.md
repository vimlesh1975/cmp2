# CMP Manual Test Checklist

This checklist is for quick manual verification after refactors, dependency updates, or setup changes.

## How To Use

1. Build the app.
2. Open the target module.
3. Run the checklist for that module.
4. Mark `Pass`, `Fail`, or `Not Tested`.
5. If the module sends commands to CasparCG, confirm both UI behavior and on-air/output behavior.

## Global Smoke Test

Run these once before module-specific testing:

- App launches from Visual Studio.
- Main shell opens without startup errors.
- CasparCG connection succeeds.
- Templates, media, and server paths are loaded correctly.
- Docked modules open and close correctly.
- App shutdown is clean.

## Core Shell And Shared Forms

| Module | Manual checklist |
| --- | --- |
| `frmMediaPlayer` | Connect to CasparCG, disconnect, reopen key docked modules, verify server/media/template paths populate, verify status labels and shell controls respond. |
| `frmfileinformation` | Open file info window, verify it shows expected metadata and opens in the correct position without layout issues. |
| `Form1` | Add media, add dummy media, play all, pause all, resume all, clear channel, save composition, reopen composition, verify restored items play correctly. |
| `frmXDCamContoller` | Open form, verify default service address and launch flow, confirm no startup error. |
| `frmROI` | Open ROI form, verify it loads and basic region editing still works. |
| `mdlcmp1` | Indirectly verify shared helpers by checking fill/position changes, external player launches, and common Caspar command paths in other modules. |
| `BuildString` | Verify text encoding/decoding in modules that send template data with special characters. |
| `ApplicationEvents` | Start app normally and verify no unexpected startup/shutdown behavior. |
| `Settings` | Launch app, save settings, restart, and verify key settings persist. |
| `CalendarColumn` | Open a scheduler grid using time columns and verify time editing, validation, and saving. |
| `CalendarColumnDateWise` | Open the date-wise scheduler grid and verify date/time editing and validation. |
| `ClsResizeableControl` | In composition-style modules, resize and move controls and confirm handles and positions behave correctly. |
| `ClsResizeableControlNew` | Verify the newer resizable control variant behaves correctly in modules that use it. |
| `VolumeMixer` | Open the mixer utility and verify basic volume adjustment behavior. |

## CG And Template Modules

| Module | Manual checklist |
| --- | --- |
| `ucCG` | Test play/stop for one-line, two-line, three-line, four-line, clock, and live phone-in graphics. |
| `ucCG2` | Test 1-line through 10-line templates, center/venue/event/victory/official templates, next-step actions, file open/save, logo selection, and animation in/out modes. |
| `ucTemplate` | Open a template, populate fields, play, stop, update, test rundown play, preview update, and confirm CG add/play command reaches CasparCG. |
| `ucHtmlTemplate` | Load rundown/template data, play HTML template, play from rundown, update live fields, stop, and confirm HTML play/call commands reach output. |
| `ucTemplatePlaylist` | Load playlist/rundown file, step through items, play next template, save, reopen, and verify row order and data persistence. |
| `ucOneLiner` | Open one-liner file, select text, play/update/stop, change styling, and test translate button if Google credentials are configured. |
| `ucTwoLiner` | Open/save source file, edit text fields, play/update/stop, and verify HTML or template update reaches output. |
| `UcCaption` | Change text and size/position controls, verify caption movement/fill updates, and confirm on-air result. |
| `ucFullPageCaption` | Test play/update/stop, file load/save, text styling, and full-page output rendering. |
| `ucOnLineCG` | Enter remote/online CG data, play and stop graphics, and verify correct host/layer routing. |
| `ucLogo` | Open logo asset, play logo, adjust opacity, stop logo, save/open logo config, and verify on-air placement. |
| `ucOSD` | Draw or update OSD content, change colors, send update, and verify output layer responds. |
| `ucWaterMarking` | Load watermark, apply position/opacity changes, show/hide watermark, and verify final placement. |
| `ucCreatePng` | Generate PNG, verify filename increments, optionally add to playlist, and confirm generated image is usable. |
| `ucHTML` | Test generic HTML play/call/stop, YouTube/live URL flows, and any browser-based output interaction used in production. |
| `ucTab` | Open and hide the tab utility and verify it closes cleanly. |

## Scroll, News, And Text Modules

| Module | Manual checklist |
| --- | --- |
| `ucScroll` | New, open, save, save as, insert, move rows up/down, copy/paste/delete rows, play, pause, stop, change speed, select all/deselect all, and color/font updates. |
| `ucBreakingNews` | New, open, save, insert, row operations, select all/deselect all, Flash play/stop, HTML play/stop, current-story filtering, and clock show/hide. |
| `ucHtmlScroller` | Prepare scroller text, cue, play, pause, stop, speed/style changes, and verify HTML scroller starts with correct text. |
| `ucHS` | Test horizontal scroll text, logo open/play/stop, color/font changes, and crawl output. |
| `ucHS2` | Test second horizontal scroll variant, text/style updates, speed changes, and output playback. |
| `ucVS` | Test vertical scroll content update, play/stop, and style changes. |
| `ucVS2` | Test vertical scroll layer/speed updates, HTML call routing, and play/stop behavior. |
| `ucSceneScroller` | Open/save content, edit text, play/update/stop, and verify scene scroller output. |
| `ucMultiBulletScroll` | Load/select bullet items, select all/deselect all, play/update HTML scroller, and verify icon/text pairing. |
| `ucImageScroll` | Load image sequence, play, pause, resume, stop, toggle options, and verify layer routing. |
| `ucRSS` | Load RSS feed or sample items, select rows, build scroll output, play/update/stop, and verify text formatting. |
| `ucTwitter` | Load Twitter content, play/update/stop the HTML graphic, and verify row reset and data display. |
| `ucFaceBook` | Load/query Facebook data, populate rows, play/next/stop, and verify profile image/text output. |
| `ucUdpChat` | Start receive, send test message, confirm message reception/display, then stop receive cleanly. |

## Playlist, Media, And Player Modules

| Module | Manual checklist |
| --- | --- |
| `ucPlaylist` | Load playlist, browse clip tree, search clips, cue/play selected clip, next/previous item handling, and verify scale/filter controls. |
| `ucPlayFromAnyWhere` | Refresh file tree, navigate arbitrary paths, cue/play media, and verify path normalization works. |
| `UcPlaylistScheduler` | Open/save scheduler file, calculate next run, start/stop schedule, and verify scheduled playlist launch works. |
| `ucPlaylistSetting` | Change channel/OSC/resize settings, save, reopen, and verify settings apply to playlist playback. |
| `ucClipGrid` | Search media, confirm result rows, cue/play, and test slow-motion load routing from the result grid. |
| `ucVideoPlayer` | Load media from grid or picker, play/pause/stop/seek if available, and verify transport commands. |
| `ucPreview` | Start preview stream, verify VLC preview window, restart preview, and confirm URL/stream selection works. |
| `ucnewPreview` | Test plain/key preview routing and VLC playback startup for the newer preview control. |
| `ucStreamPlayer` | Start external stream playback, test NDI start/stop if used, and verify external helper commands launch. |
| `ucStreaming` | Add/remove stream target, start/stop streaming path, and verify target command text is correct. |
| `ucVlcStreamTester` | Start preview/test stream, stop and restart it, and verify VLC test behavior. |
| `ucSwfPlayer` | Load SWF, play/stop it, and verify selected path/layer output. |
| `ucPowerPoint` | Open PowerPoint file, attach/embed, toggle watcher if used, and verify presentation output flow. |
| `ucScreenConsumer` | Attach screen consumer, detach it, and verify no orphaned output remains. |
| `ucCasparcgWindow` | Parent/unparent preview window, play/load/seek media, verify audio meter colors, and check aspect-ratio resizing. |
| `uc4ChannelPlayer` | Open all four player windows, confirm each channel/player initializes, and close all cleanly. |
| `ucFourChannelPreview` | Verify all four preview panes initialize with the correct source/channel settings. |

## Recorder, Trimmer, And Slow Motion Modules

| Module | Manual checklist |
| --- | --- |
| `ucRecorder` | Select recording folder, start record, stop record, remove recorder layer if applicable, and verify file creation. |
| `ucnewRecorder` | Test newer recorder start/stop/remove flows and folder selection. |
| `ucSMRecorder` | Start/stop slow-motion recorder and verify file output path. |
| `uc4ChannelRecorderAndTrimmer` | Verify four recorders initialize, start/stop behavior, resize helpers, and shutdown cleanup. |
| `ucTrimmer` | Load media, set in/out points, save/export, and verify output file and time range. |
| `ucnewTrimmer1` | Test frame stepping, time conversion, seek controls, and export using FFmpeg/BMX tools. |
| `ucSlowMotion` | Load clip, seek, play, replay, speed changes, and verify slow-motion calls reach output. |
| `ucSlowMotion21` | Verify dual player/recorder setup, load, replay, and record coordination. |
| `ucnewSM2` | Test load, seek, replay, speed adjustment, and output routing in the newer slow-motion tool. |
| `ucdBFSMeter` | Check live audio meter polling, replay audio tests, and channel remap/pan controls. |
| `ucSystemAudio` | Toggle per-channel add/remove audio options and verify active audio routing. |
| `ucSilenceDetector` | Set threshold, start detection, verify tone/reset behavior, and test alert/source command routing. |

## Scheduler, Command, And Utility Modules

| Module | Manual checklist |
| --- | --- |
| `ucAMCPcommands` | New/open/save AMCP file, send command, verify response text, and reset command area. |
| `UcCommandScheduler` | New/open/save schedule, start/stop scheduler, wait for a test row, and verify multi-command execution. |
| `UcCommandSchedulerDateWise` | New/open/save dated schedule, start/stop scheduler, verify expired-row cleanup and command execution. |
| `ucOSC` | Trigger OSC messages from upstream source if available and verify rows populate correctly. |
| `ucRemoteLogging` | Connect/disconnect remote logging target and verify socket cleanup and state labels. |
| `ucUtility` | Open configured folder, open latest log, open latest as-run log, and verify server-relative paths resolve correctly. |
| `ucWebSocketServer` | Start server, send/receive a test payload, verify status text and hidden text/output updates. |
| `ucMySqlTest` | Open DB connection, run a sample query, render HTML/table output, and verify color-picker or display helpers. |
| `ucMetadata` | Read metadata from a sample media file, edit metadata, save, and verify changes persist. |
| `ucMAM` | Browse folders, populate media list, launch external utility commands, and verify bulk transcoder selection. |
| `ucTranscodingProfile` | Load profiles/codecs, switch output extension/profile values, and save/apply settings. |

## Device, Router, And External Integration Modules

| Module | Manual checklist |
| --- | --- |
| `ucMixer` | Test opacity, brightness, saturation, contrast, fill, clip, levels, anchor, rotation, perspective, crop, save/open mixer settings, get status, and master/layer volume. |
| `ucMixernew` | Run the same checks as `ucMixer` on the newer mixer UI and verify status/save/load behavior. |
| `ucPositionAndSize` | Change position/size/fill values and verify layer fill command updates output correctly. |
| `ucVDCPController` | Connect to VDCP target, send cue/play commands, and verify serial/TCP control path. |
| `ucVTRController` | Send cue/play/transport commands to the serial VTR target and confirm device response. |
| `ucVisionMixer` | Change route/color/transition selections and verify vision mixer command output. |
| `ucChannelInfo` | Fetch channel info, verify rows populate for your CasparCG version, and test stop/remove actions. |
| `ucNDISource` | Refresh NDI list, parse source names, and verify selection/close behavior. |
| `ucCCTV` | Load camera list, start four-camera group playback, test timer/camera switching, and verify RTSP routing. |
| `ucnewOffAirLogger` | Open/save schedule, start/stop recording logger, verify decklink/clock commands and file output. |
| `ucOffAirLogger` | Initialize single logger, start/stop logging, and verify cleanup. |
| `ucOffAirLoggers` | Initialize multiple loggers and confirm coordinated startup/shutdown. |
| `ucXdcamController` | Populate XDCAM clip grid, browse clips, and test basic control workflow. |
| `ucXdcamSoapClient` | Populate SOAP XDCAM clip grid and confirm clip listing/selection. |

## Sports And Event Graphics Modules

| Module | Manual checklist |
| --- | --- |
| `ucCricket` | Test score play/update variants, striker marker logic, event/player/venue graphics, and confirm HTML output updates. |
| `ucdc` | Test Davis Cup scorebug, service icon, info straps, and static template screens. |
| `ucPlayers` | Pick player photo/flag assets, play related templates, and confirm correct player data on air. |
| `ucRCCAutomation` | Load flags/data and run upload or automation flow against a test endpoint. |
| `ucRccBall` | Test device/output mode changes, animation commands, and logo-picker flows. |
| `ucNG2015` | Run sports/logo picker flows and shooting-series related buttons. |
| `ucSG2016` | Test logo pickers and main animation mixer actions. |
| `ucWeightLifting` | Load athlete/country data, logos, and verify scoreboard/template output. |
| `ucQuiz` | Open/save quiz file, move rows, play/update quiz graphics, and verify encoded text rendering. |
| `ucWeather` | Open/save weather data, update icon mappings, play/update output, and verify weather graphics. |

## Subtitle, Social, And Online Modules

| Module | Manual checklist |
| --- | --- |
| `ucSongSubtitling` | Load/edit subtitle rows, send OSC updates, play/step through lyric lines, and verify timing. |
| `ucSrtPlayer` | Open SRT, shift timing, play subtitles, and verify encoded output lines appear at the right times. |
| `ucytlive` | Verify timezone calculation, schedule rows, and any YouTube Live scheduling/start controls you use. |

## Quick Regression Suites

### Minimal On-Air Graphics Suite

- `ucCG`
- `ucTemplate`
- `ucHtmlTemplate`
- `ucScroll`
- `ucBreakingNews`
- `ucLogo`
- `UcCaption`

### Minimal Playback Suite

- `ucPlaylist`
- `ucClipGrid`
- `ucPreview`
- `ucVideoPlayer`
- `ucRecorder`
- `ucTrimmer`

### Minimal Integration Suite

- `frmMediaPlayer`
- `ucMixer`
- `ucUtility`
- `UcCommandScheduler`
- `ucWebSocketServer`
- `ucCasparcgWindow`

## Test Result Template

Use this format while testing:

```text
Date:
Build:
Tester:

Module: ucTemplate
- Open template: Pass
- Play: Pass
- Update: Pass
- Stop: Pass
- Rundown play: Fail - did not send command on row 2

Module: ucScroll
- Open file: Pass
- Save: Pass
- Play: Pass
- Pause: Pass
- Stop: Pass
```
