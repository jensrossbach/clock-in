# Changelog
All notable changes to this project will be documented in this file.
The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/).

## [3.2.6967.34578] - 2019-01-28

### Added
- Automatic clocking in (configurable) when unlocking Windows session

### Changed
- Redesigned options dialog with various layout optimizations
- Last tab page in options dialog is now remembered
- Changed green variant of modern icon to a lighter green

### Fixed
- No overlapping for absence time period check when clocking in

## [3.1.6948.33999] - 2019-01-09

### Added
- System tray icon shows working state and level
- Possibility to specify time offsets for session reset, clock in and clock out

### Changed
- Options and absence dialogs show up at OS default position
- Removed minimize/restore animation when closing/restoring main window

### Fixed
- When resetting session during being clocked out, working state is not reset
- Hotkey for restoring main window not working before opening the main window for the first time

## [3.0.6940.24229] - 2019-01-01

### Added
- Possibility to clock out and clock in (recorded breaks)
- Option to use system notifications for working time notifications

### Changed
- Use global hotkey registration instead of low-level keyboard hooks
- Improved working time notification sequence
- Use error indicators for validation errors instead of message boxes
- Small bugfixes, optimizations and improvements under the hood

### Fixed
- Main window not showing up in front of all others when pressing hotkey (blinking taskbar icon instead)

## [2.5.6895.31440] - 2018-11-17

### Added
- Usage of flat system tray icon on Windows 8 or newer is now configurable

### Changed
- Tooltip text of system tray icon reduced to one line without application name

## [2.4.6889.20160] - 2018-11-11

### Added
- Pressing hotkey brings main window to front if already visible
- New flat system tray icon on Windows 8 or newer

### Changed
- Internal improvements

### Fixed
- System tray icon tooltip shows wrong leave time after reaching end of regular working time when main window is minimized
- In some special constellation, notification popup does not occur after reaching end of regular or maximum working time

## [2.3.6881.28576] - 2018-11-03

### Added
- System tray icon tooltip shows leave time
- Next day detection

### Changed
- Many under the hood improvements

## [2.2.6872.22519] - 2018-10-25

### Added
- Possibility for notification ahead of regular working time limit
- Option to start application in foreground

### Changed
- Internal code improvements

## [2.1.6858.34889] - 2018-10-11

### Added
- Possibility to specify start time offset

### Fixed
- Wrong title of system tray icon
- No recalculation of late shift break adder when resuming from energy saving mode

## [2.0.6853.21047] - 2018-10-06

### Added
- Possibility to specify individual break/absence periods
- Button to reset session (replaces double click on start time label)
- Possibility to specify up to two discounted break periods depending on elapsed working time when starting work after lunch break period ("late shift")

### Changed
- Settings dialog split into multiple tabs

### Fixed
- Improved appliance of working time and absence rules

## [1.0.5643.24908] - 2015-06-14

### Added
- Support for opening main window through system wide hotkey

### Fixed
- Missing German translation for notification window always on top option
- Wrong tab order in options dialog

## [0.4.5259.34766] - 2014-05-26

### Fixed
- Manual session reset sets arrival time to application start time

## [0.4.5258.26173] - 2014-05-25

### Fixed
- Improved icon image resource storage

## [0.4.5257.38620] - 2014-05-24

### Added
- Clicking on elapsed/remaining time icon now also switches between elapsed and remaining time
- Clicking on end time icon/value updates values (for the case when focus still on start time field)
- Double clicking on start time label resets session
- New checkbox below time display box to always show values related to maximum working time

### Fixed
- No update of end time when clicking into elapsed/remaining time display after changing start time
- Duplicate keyboard shortcut assignment in German version of options screen

## [0.3.5246.36617] - 2014-05-13

### Added
- Option to have notification window always on top

### Changed
- New design for stopwatch, timer and power icons

### Fixed
- (hopefully ;-)) Main window and notification popup sometimes opening in background

## [0.2.4614.31929] - 2012-08-19

### Added
- Remaining working time can now be displayed additionally to elapsed working time (toggle between both by clicking on time value)
- Leave time now displayed below working time
- Possibility to let application automatically start together with Windows

### Changed
- Changes of start time and break duration now update displays and timers not before leaving controls

### Fixed
- Sporadic exception when timer interval became 0
- Main window and notification popup sometimes opening in background
- Image quality of smiley icons

## [0.1.4431.35506] - 2012-03-29
First version
