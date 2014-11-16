﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AutomationTestAssistantCore
{
    public class FilesDeleter
    {
        public void DeleteAllFilesAndFolders(string dirPath)
        {
            if (Directory.Exists(dirPath))
            {
               DirectoryInfo dir= new DirectoryInfo(dirPath);
               //string dirPathForDeletion = String.Concat(dir.Root, dir.FullName.Split('\\')[1]);
               //DirectoryInfo delDir = new DirectoryInfo(dirPathForDeletion);
               dir.Attributes &= ~FileAttributes.ReadOnly;
               DeleteFilesAndDirs(dir);
               //delDir.Delete(true);
            }
            //else
            //{
            //    throw new DirectoryNotFoundException("Please select existing directory path");
            //}
        }

        private static void DeleteFilesAndDirs(DirectoryInfo delDir)
        {
            foreach (DirectoryInfo cd in delDir.GetDirectories())
            {
                cd.Attributes &= ~FileAttributes.ReadOnly;
                foreach (FileInfo cf in cd.GetFiles())
                {
                    cf.Attributes &= ~FileAttributes.ReadOnly;
                    File.Delete(cf.FullName);
                }
                DeleteFilesAndDirs(cd);
                cd.Delete(true);
            }
        }
    }
}
