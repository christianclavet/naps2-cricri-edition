# NAPS 2 CRICRI EDITION
## NOTES (About this fork): 
Here is the current release [(6.2.3 Un-official)](https://github.com/christianclavet/naps2-cricri-edition/releases/tag/v6.2.3_CriCri_Edition)


## Darkmode activated
<img src="https://github.com/christianclavet/naps2-cricri-edition/assets/13395943/1fab8b6f-e11d-42e5-ade6-ac5c14701c54" width="729" height="364">

## Darkmode deactivated
<img src="https://github.com/christianclavet/naps2-cricri-edition/assets/13395943/844162e4-a2cd-4b72-bb6d-893a076954ce" width="729" height="364">

This is an unofficial release. This fork could be compared to Naps2 v6.2, as it's based upon Naps 6.1.2 Official.

This fork and versions have these new features that have been added:

### **Interface**
- Each icon for images are numbered. You can also immediately know how many pictures you have in your current project
- There is a status bar with more information on the picture: ex. resolution, color depth, barcode info (if present)
- There is a new preview windows with a splitter bar on the main windows that allow you to check the image without having to open in the image editor 
- Changed interface with bigger icons. Was feeling too small on 4k screens and still look nice on 2k screens.
- Reworked the menus workflow. Each command that is assigned to shortcuts are displayed, and there is some mouse over information.
- When new pictures are received (import or scan) the display will scroll to the last visible line 
- Started "Darkmode" for the interface. This can be changed from the user in the menu (standard | darkmode). Mostly apply to the main interface for now.

### **Scanning**
- The current used device is directly on the toolbar. If you change the device (F1, F2, F3, etc) the device will be changed for the current device. This behavior is different from Vanilla NAPS2
- Added feature to rescan a page with a new image. You select the page and press the "scan" button. It will ask if you want to replace the image. 
- Added feature to insert images between pages. You select the page that you want before the added picture and press the new "insert Scan" button.
- Barcodes are read from the application and displayed. Plan to later have metadata's and store theses (export and multi-projects). A single page barcode is supported for the moment. 

### **Export**
- PDF re-compression is now supported. It is recommended to use with the MAX Quality features from the scanner profile (advanced). This would allow you to scan at the max quality and recompress the PDF to make it smaller. (Very useful for sending documents in small mailboxes)

### **Project**
- This application support basic project management. Still work to do...
- You can "close" the current project and it will be saved, you can also name the project to easier retrieval at a later time or on another computer.
- You can now load a previously saved project. Using the FOLDER requestor for now to access the folder and retrieve for new editing or adding.

*NOTES:*
The application build is in 64bit and support all the memory you have. 

I plan to give back some patches to official NAPS 7.0+ (Already done the first one with the help of  @cyanfish) but the author will decide if he incorporate it or not. I don't have the hardware for building for Linux and Mac (nor the will to). I will still developing for windows only as it's my main platform of use here and at work. 

- [Get current release installer (6.2.3 unofficial) HERE](https://github.com/christianclavet/naps2-cricri-edition/releases/tag/v6.2.3_CriCri_Edition)
- [Get current release installer (6.2.0 unofficial) HERE](https://github.com/christianclavet/naps2-cricri-edition/releases/tag/v6.2.0_CriCri_Edition)

### Others informations about NAPS: (From official REPO)
## NAPS2 (Not Another PDF Scanner 2) (CriCri Edition - Fork of NAPS2)

NAPS2 is a document scanning application with a focus on simplicity and ease of use. Scan your documents from WIA- and TWAIN-compatible scanners, organize the pages as you like, and save them as PDF, TIFF, JPEG, PNG, and other file formats. Requires .NET Framework 4.5 or higher.

Visit the NAPS2 home page at [www.naps2.com](http://www.naps2.com).

Other links:
- [Documentation](http://www.naps2.com/support.html)
- [Translations](http://translate.naps2.com/) - [Doc](http://www.naps2.com/doc-translations.html)
- [File a Ticket](https://sourceforge.net/p/naps2/tickets/) - For bug reports, feature requests, and general support inquiries.
- [Discussion Forums](https://sourceforge.net/p/naps2/discussion/general/) - For more open-ended discussion.
- [Donate](https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=M77MFAP2ZV9RG)

## For developers
Have a look at the [Developer Onboarding](https://www.naps2.com/doc-dev-onboarding.html) page.

