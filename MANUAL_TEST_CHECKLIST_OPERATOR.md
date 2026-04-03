# CMP Operator Test Sheet

Use this sheet for fast post-build checking.

Mark each line:

- `[ ]` Not tested
- `[P]` Pass
- `[F]` Fail

## Startup

- [ ] App starts
- [ ] CasparCG connects
- [ ] Main modules open
- [ ] No startup error
- [ ] App closes cleanly

## Graphics Core

### `ucCG`
- [ ] Clock play
- [ ] Clock stop
- [ ] One line play
- [ ] Two line play
- [ ] Three line play
- [ ] Four line play
- [ ] Live phone-in play
- [ ] Stop works

### `ucCG2`
- [ ] 1-10 line template play
- [ ] Venue/Event/Victory/Official play
- [ ] Next-step action
- [ ] Logo select
- [ ] File open/save
- [ ] In animation
- [ ] Out animation

### `ucTemplate`
- [ ] Template opens
- [ ] Fields load
- [ ] Play works
- [ ] Update works
- [ ] Stop works
- [ ] Rundown play works

### `ucHtmlTemplate`
- [ ] Rundown loads
- [ ] HTML play works
- [ ] HTML update works
- [ ] Stop works
- [ ] Play from rundown works

### `ucOneLiner`
- [ ] File open
- [ ] Play
- [ ] Update
- [ ] Stop
- [ ] Style change
- [ ] Translate

### `ucTwoLiner`
- [ ] File open/save
- [ ] Play
- [ ] Update
- [ ] Stop

### `UcCaption`
- [ ] Text update
- [ ] Move/resize
- [ ] Output correct

### `ucFullPageCaption`
- [ ] File open/save
- [ ] Play
- [ ] Update
- [ ] Stop

### `ucLogo`
- [ ] Logo open
- [ ] Logo play
- [ ] Opacity change
- [ ] Stop

### `ucHTML`
- [ ] HTML play
- [ ] HTML call/update
- [ ] HTML stop
- [ ] URL/live page works

## Scroll And News

### `ucScroll`
- [ ] New
- [ ] Open
- [ ] Save
- [ ] Insert
- [ ] Move rows
- [ ] Copy/paste/delete
- [ ] Play
- [ ] Pause
- [ ] Stop
- [ ] Color/font update

### `ucBreakingNews`
- [ ] New/Open/Save
- [ ] Move rows
- [ ] Select all/deselect all
- [ ] Flash play/stop
- [ ] HTML play/stop
- [ ] Current story filter
- [ ] Clock show/hide

### `ucHtmlScroller`
- [ ] Text update
- [ ] Cue
- [ ] Play
- [ ] Pause
- [ ] Stop
- [ ] Style/speed update

### `ucHS`
- [ ] Text update
- [ ] Logo open/play
- [ ] Stop
- [ ] Style update

### `ucHS2`
- [ ] Text update
- [ ] Play
- [ ] Stop
- [ ] Style/speed update

### `ucVS`
- [ ] Play
- [ ] Stop
- [ ] Speed/style update

### `ucVS2`
- [ ] Play
- [ ] Stop
- [ ] Speed update
- [ ] HTML call update

### `ucRSS`
- [ ] Feed/items load
- [ ] Row select
- [ ] Play
- [ ] Update
- [ ] Stop

### `ucSceneScroller`
- [ ] Open/save
- [ ] Play
- [ ] Update
- [ ] Stop

## Playlist And Playback

### `ucPlaylist`
- [ ] Playlist open
- [ ] Clip tree browse
- [ ] Search works
- [ ] Cue
- [ ] Play
- [ ] Next item
- [ ] Filter/scale change

### `ucClipGrid`
- [ ] Search
- [ ] Result rows
- [ ] Cue
- [ ] Play
- [ ] Slow-motion load

### `ucPlayFromAnyWhere`
- [ ] Tree refresh
- [ ] Browse path
- [ ] Cue
- [ ] Play

### `ucVideoPlayer`
- [ ] Media load
- [ ] Play
- [ ] Pause
- [ ] Stop
- [ ] Seek

### `ucPreview`
- [ ] Preview start
- [ ] Preview visible
- [ ] Restart works

### `ucnewPreview`
- [ ] Preview start
- [ ] Plain/key mode
- [ ] Preview visible

### `ucStreamPlayer`
- [ ] Stream start
- [ ] Stream stop
- [ ] NDI path works

### `ucStreaming`
- [ ] Add target
- [ ] Remove target
- [ ] Start/stop route

### `ucSwfPlayer`
- [ ] Load SWF
- [ ] Play
- [ ] Stop

### `ucPowerPoint`
- [ ] Open PPT
- [ ] Attach/embed
- [ ] Output visible

## Recorder And Slow Motion

### `ucRecorder`
- [ ] Folder select
- [ ] Record start
- [ ] Record stop
- [ ] File created

### `ucnewRecorder`
- [ ] Folder select
- [ ] Record start
- [ ] Record stop
- [ ] File created

### `ucSMRecorder`
- [ ] Record start
- [ ] Record stop
- [ ] File created

### `ucTrimmer`
- [ ] Media load
- [ ] In point
- [ ] Out point
- [ ] Export
- [ ] Output file OK

### `ucnewTrimmer1`
- [ ] Media load
- [ ] Step/seek
- [ ] In/out
- [ ] Export

### `ucSlowMotion`
- [ ] Load clip
- [ ] Replay
- [ ] Seek
- [ ] Speed change

### `ucSlowMotion21`
- [ ] Player setup
- [ ] Recorder setup
- [ ] Replay
- [ ] Record link

### `ucnewSM2`
- [ ] Load clip
- [ ] Replay
- [ ] Seek
- [ ] Speed change

### `ucdBFSMeter`
- [ ] Meter live
- [ ] Replay test
- [ ] Channel remap

## Mixer And Device Control

### `ucMixer`
- [ ] Opacity
- [ ] Brightness
- [ ] Saturation
- [ ] Fill
- [ ] Crop
- [ ] Perspective
- [ ] Save/open preset
- [ ] Status read

### `ucMixernew`
- [ ] Opacity
- [ ] Fill
- [ ] Crop
- [ ] Save/open preset
- [ ] Status read

### `ucPositionAndSize`
- [ ] Position update
- [ ] Size update
- [ ] Output correct

### `ucVDCPController`
- [ ] Connect
- [ ] Cue
- [ ] Play
- [ ] Response OK

### `ucVTRController`
- [ ] Cue
- [ ] Play
- [ ] Transport command works

### `ucVisionMixer`
- [ ] Route change
- [ ] Transition command
- [ ] Color command

### `ucChannelInfo`
- [ ] Fetch info
- [ ] Rows show
- [ ] Stop/remove row

### `ucNDISource`
- [ ] Source list loads
- [ ] Source select

### `ucCCTV`
- [ ] Camera list loads
- [ ] Camera play
- [ ] Group/timer switch

## Utility And Automation

### `ucAMCPcommands`
- [ ] Open/save command file
- [ ] Send command
- [ ] Response shown
- [ ] Reset

### `UcCommandScheduler`
- [ ] Open/save schedule
- [ ] Start
- [ ] Stop
- [ ] Test row runs

### `UcCommandSchedulerDateWise`
- [ ] Open/save schedule
- [ ] Start
- [ ] Stop
- [ ] Test row runs

### `ucOSC`
- [ ] OSC rows update

### `ucUtility`
- [ ] Open folder
- [ ] Open latest log
- [ ] Open latest as-run log

### `ucWebSocketServer`
- [ ] Start server
- [ ] Send/receive test
- [ ] Status updates

### `ucMySqlTest`
- [ ] Connect
- [ ] Run test query
- [ ] Result display OK

### `ucMetadata`
- [ ] Read metadata
- [ ] Edit metadata
- [ ] Save metadata

### `ucMAM`
- [ ] Browse folder
- [ ] Media list loads
- [ ] Utility command runs

## Sports And Special Modules

### `ucCricket`
- [ ] Score play
- [ ] Score update
- [ ] Striker mark
- [ ] Event/player/venue output

### `ucdc`
- [ ] Scorebug
- [ ] Service icon
- [ ] Info strap
- [ ] Static template play

### `ucPlayers`
- [ ] Player image/flag pick
- [ ] Related template play

### `ucRCCAutomation`
- [ ] Load data
- [ ] Upload/send test

### `ucRccBall`
- [ ] Device mode
- [ ] Animation command
- [ ] Logo select

### `ucNG2015`
- [ ] Logo picker
- [ ] Sports action buttons

### `ucSG2016`
- [ ] Logo picker
- [ ] Animation commands

### `ucWeightLifting`
- [ ] Country/data load
- [ ] Graphic output

### `ucQuiz`
- [ ] Open/save
- [ ] Row move
- [ ] Play/update

### `ucWeather`
- [ ] Open/save
- [ ] Icon mapping
- [ ] Play/update

## Fast Daily Check

Run these if time is short:

- [ ] `frmMediaPlayer` launch/connect
- [ ] `ucCG` basic play/stop
- [ ] `ucTemplate` play/update/stop
- [ ] `ucHtmlTemplate` play/update/stop
- [ ] `ucScroll` open/play/stop
- [ ] `ucBreakingNews` HTML play/stop
- [ ] `ucPlaylist` search/play
- [ ] `ucPreview` preview visible
- [ ] `ucRecorder` record start/stop
- [ ] `ucMixer` fill/opacity
- [ ] `ucUtility` latest log open

## Notes

```text
Date:
Build:
Tester:

Fails / remarks:
- 
- 
- 
```
