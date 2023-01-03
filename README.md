# NAPS2 (Not Another PDF Scanner 2) (CriCri Edition - Fork of NAPS2)

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

## NOTE (About this fork): 
I, Christian Clavet, not the original developper of this excellent application, plan to rework the application for supporting a method I prefer for Batch Scanning as post-process in a non-destructive manner. I also want to experiment with improving the workflow of the application and add other small features.

I also had to upgrade the requirement for .NET Framework going from 4.0 to 4.8 because, I also updated the libraries used in the application and they now require .NET Framework 4.8+

Here is the current preview 2 (January 2023)
![Alt text](./ScreenPreview2.jpg?raw=true "Title")
Here is a screenshot (july 2022)
![Alt text](./Naps2_Barcode.JPG?raw=true "Title")

Specific features of this fork:
- Internal image viewer
- All thumbnails are numbered now. Easier to manage
- Ability to rescan an image. Select the image and press the SCAN button; it will ask you if you want to replace the image.
- Ability to import at a specifc position, by selecting an image and pressing the IMPORT button. Images will be insert right after the selection
- Ability to insert scanned image from a specific position, by selecting an image and pressing the SCAN INSERT button.
- There are now tooltips
- More to come!
