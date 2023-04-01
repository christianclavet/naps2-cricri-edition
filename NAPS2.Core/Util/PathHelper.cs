using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NAPS2.Util
{
    public static class PathHelper
    {
        /// <summary>
        /// Creates the parent directory for the provided path if needed.
        /// </summary>
        /// <param name="filePath"></param>
        public static void EnsureParentDirExists(string filePath)
        {
            var parentDir = new FileInfo(filePath).Directory;
            if (parentDir != null && !parentDir.Exists)
            {
                parentDir.Create();
            }
        }

        //Copy a folder - sourceDir is always the currently active working folder
        public static void CopyDirectory(string sourceDir, string destinationDir, bool recursive)
        {
            // Get information about the source directory
            var dir = new DirectoryInfo(sourceDir);
            var dir1 = new DirectoryInfo(destinationDir);
            var dir2 = new DirectoryInfo(destinationDir+"_old");

            // Check if the source directory exists
            if (!dir.Exists)
                throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");

            // Cache directories before we start copying
            DirectoryInfo[] dirs = dir.GetDirectories();

            // Delete the "old" folder if it exist the user really want to update with a new revision. The "old" folder will be deleted before creating a new one.
            if (dir2.Exists)
                dir2.Delete(true);

            // Moving the existing destination dir before updating with the content
            if (dir1.Exists)
            {
                dir1.MoveTo(destinationDir + "_old"); // TODO Need to check if the old already exist
            }

            // Create the destination directory
            Directory.CreateDirectory(destinationDir);

            // Get the files in the source directory and copy to the destination directory
            foreach (FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationDir, file.Name);
                file.CopyTo(targetFilePath);
            }

            // If recursive and copying subdirectories, recursively call this method
            if (recursive)
            {
                foreach (DirectoryInfo subDir in dirs)
                {
                    string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                    CopyDirectory(subDir.FullName, newDestinationDir, true);
                }
            }
        }
    }

}
