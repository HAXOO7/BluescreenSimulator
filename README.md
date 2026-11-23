# BluescreenSimulator
This is a simple Bluescreen Simulator for Windows with lots of customizable features. It will not crash your PC; it just displays a full screen window.

## Cannot exit the simulated BSOD?

- Press F7.
- If that does not work, try Fn+F7.
- If that does not work either, click anywhere once, then try F7 and Fn+F7 again.
- By now, you should have exited the screen. This absolutely has to work.

## About anti-virus detection

Sometimes, BluescreenSimulator (and especially its generated EXE files) will be flagged as malware by several anti-virus programs (Avast, AVG, Norton, McAfee, Windows Defender, etc.), this, however, is a false positive.

3 things cause this to happen:
a) Because the program executable isn't signed
b) Some antiviruses detect this as a joke program (which it is)
c) The keyboard hook used to inhibit key presses looks suspicious to many heuristics

If downloaded from our(!) GitHub, the program is safe to use (we cannot give this promise if you download it from somewhere else!). It is okay if you do not trust us; you can always go ahead and compile it yourself.

For a tutorial on how to exclude this program from your antivirus so it can run anyway, check out these links:

    Windows Defender: https://support.microsoft.com/en-us/windows/add-an-exclusion-to-windows-security-811816c0-4dfd-af4a-47e4-c301afe13b26
    Avast: https://support.avast.com/en-ww/article/Antivirus-scan-exclusions#pc
    AVG: https://support.avg.com/SupportArticleView?l=en&urlName=avg-antivirus-scan-exclusion
    Norton: https://support.norton.com/sp/en/us/home/current/solutions/v3672136
    McAfee: https://www.mcafee.com/support/?page=shell&shell=article-view&articleId=TS102056
    For other antiviruses, try searching for "<antivirus name> add exception"

## How to contribute:
- Fork the project
- Clone your forked project to your hard drive using one of the following commands:
	-  `git clone git@github.com:YourName/BluescreenSimulator.git`
	-  `git clone https://github.com/YourName/BluescreenSimulator.git`
- Create a new branch:
	- `git checkout -b  ANameDescribingYourBranch`
- Commit and push your changes regularly:
	- `git add .`
	- `git commit -m "Commit message explaining your changes"`
	- `git push`
- When you're done, create a Pull Request from your repository to this repository's master branch.


## Windows 11 24H2+ Black Stop-Error Simulation (Fork addition)

This fork adds a separate **Windows 11 Black (24H2+)** tab. The layout follows Microsoft's published Windows 11 24H2+ stop-error reference: centered restart message and completion percentage, with the stop code (including its hexadecimal value) and optional faulting module centered near the bottom. The new screen omits the legacy frowny face and QR code.

Configurable fields include the main message, stop code, hexadecimal code, faulting driver/module, text delay, progress duration, mouse cursor visibility, full-screen/windowed mode, and optional timed auto-close. The default values mirror Microsoft's published example (`CRITICAL_PROCESS_DIED`, `0xEF`, `rdbyss.sys`).

The new screen is an ordinary WPF window simulation. It does not issue a bugcheck, change system settings, install drivers/services, or add a global keyboard hook. Press **F7** or **Esc** while the new screen is focused to exit. Existing Windows 10, Windows 7, and Windows 9x screens are retained.

Microsoft reference: https://techcommunity.microsoft.com/blog/windows-itpro-blog/resilience-in-action-for-windows-devices/4434571
