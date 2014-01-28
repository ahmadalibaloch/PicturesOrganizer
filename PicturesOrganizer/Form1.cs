using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PicturesOrganizer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonSelectFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowDialog();
            textBoxFolderPath.Text = folderBrowserDialog.SelectedPath;
        }

        private void buttonStartOrganizing_Click(object sender, EventArgs e)
        {
            string folderPath = textBoxFolderPath.Text;
            string folderOutputPath = textBoxOutputFolderPath.Text;
            string newName = textBoxNewName.Text;
            if (folderPath.Length < 1 || folderOutputPath.Length < 1)
            {
                MessageBox.Show("Enter valid pictures and output path!", "Invalid Path", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            if (checkBoxNewName.Checked && newName.Length < 1)
            {
                MessageBox.Show("Enter valid new name for pictures!", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            if (checkBoxFileNameDate.Checked && textBoxFileNameDateFormat.Text.Length < 1)
            {
                MessageBox.Show("Enter a date/time format!", "Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            DateTime customDateTime = DateTime.Today;
            if (radioButtonDateCustom.Checked)
                customDateTime = dateTimePicker1.Value;
            organizerPictures(folderPath, folderOutputPath, customDateTime);
        }

        public void organizerPictures(string folderPath, string folderOutputPath, DateTime customDateTime)
        {
            if (!Directory.Exists(folderPath))
                return;
            if (!Directory.Exists(folderOutputPath))
                if (!Directory.CreateDirectory(folderOutputPath).Exists)
                {
                    MessageBox.Show("Enter valid output path!", "Invalid Path", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return;
                }
            if (textBoxFileExtensions.Text.Length < 2)
            {
                MessageBox.Show("Enter valid file extensions!", "Invalid File Extension", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            PicutresFolder folder = new PicutresFolder(folderPath);
            folder.supportedExtensions = textBoxFileExtensions.Text;

            foreach (PicutresFolder subFolder in folder.getDirectories())
            {
                organizerPictures(subFolder.FullName, folderOutputPath, customDateTime);
            }
            DirectoryInfo folderOutput = new DirectoryInfo(folderOutputPath);
            DateTime modifiedDateTime;
            String yearPath;
            String monthPath;
            String datePath;

            bool chkMonthFolder = checkBoxMonthFolder.Checked;
            bool chkDateFolder = checkBoxDateFolder.Checked;
            bool chkMoveFiles = radioButtonMoveFiles.Checked;
            bool chkFileNameDate = checkBoxFileNameDate.Checked;
            bool chkFileNewName = checkBoxNewName.Checked;
            bool chkSetNewDate = checkBoxSetNewDate.Checked;
            #region NoNewDate
            if (!chkSetNewDate)
            {
                #region NoNewNameFile
                if (!chkFileNewName)
                {
                    #region FileMetaDataDate
                    if (!chkFileNameDate)
                    {
                        #region MoveFiles
                        if (chkMoveFiles)
                        {
                            #region YearPath
                            if (!chkMonthFolder && !chkDateFolder)
                            {
                                foreach (FileInfo fileInfo in folder.getPictures())
                                {
                                    modifiedDateTime = fileInfo.LastWriteTime;
                                    yearPath = folderOutput.FullName + "\\" + modifiedDateTime.Year + "\\";
                                    if (!Directory.Exists(yearPath))
                                        Directory.CreateDirectory(yearPath);
                                    if (!File.Exists(yearPath + fileInfo.Name))
                                        fileInfo.MoveTo(yearPath + fileInfo.Name);
                                }
                            }
                            #endregion
                            #region MonthPath
                            else if (chkMonthFolder && !chkDateFolder)
                            {
                                foreach (FileInfo fileInfo in folder.getPictures())
                                {
                                    modifiedDateTime = fileInfo.LastWriteTime;
                                    monthPath = folderOutput.FullName + "\\" + modifiedDateTime.Year + "\\" + modifiedDateTime.Month + modifiedDateTime.ToString(". MMM") + "\\";
                                    if (!Directory.Exists(monthPath))
                                        Directory.CreateDirectory(monthPath);
                                    if (!File.Exists(monthPath + fileInfo.Name))
                                        fileInfo.MoveTo(monthPath + fileInfo.Name);
                                }
                            }
                            #endregion
                            #region DatePath
                            else if (chkMonthFolder && chkDateFolder)
                            {
                                foreach (FileInfo fileInfo in folder.getPictures())
                                {
                                    modifiedDateTime = fileInfo.LastWriteTime;
                                    datePath = folderOutput.FullName + "\\" + modifiedDateTime.Year + "\\" + modifiedDateTime.Month + modifiedDateTime.ToString(". MMM") + "\\" + modifiedDateTime.Day + "\\";
                                    if (!Directory.Exists(datePath))
                                        Directory.CreateDirectory(datePath);
                                    if (!File.Exists(datePath + fileInfo.Name))
                                        fileInfo.MoveTo(datePath + fileInfo.Name);
                                }
                            }
                            #endregion
                        }
                        #endregion
                        #region CopyFiles
                        else
                        {
                            #region YearPath
                            if (!chkMonthFolder && !chkDateFolder)
                            {
                                foreach (FileInfo fileInfo in folder.getPictures())
                                {
                                    modifiedDateTime = fileInfo.LastWriteTime;
                                    yearPath = folderOutput.FullName + "\\" + modifiedDateTime.Year + "\\";
                                    if (!Directory.Exists(yearPath))
                                        Directory.CreateDirectory(yearPath);
                                    if (!File.Exists(yearPath + fileInfo.Name))
                                        fileInfo.CopyTo(yearPath + fileInfo.Name);
                                }
                            }
                            #endregion
                            #region Monthpath
                            else if (chkMonthFolder && !chkDateFolder)
                            {
                                foreach (FileInfo fileInfo in folder.getPictures())
                                {
                                    modifiedDateTime = fileInfo.LastWriteTime;
                                    monthPath = folderOutput.FullName + "\\" + modifiedDateTime.Year + "\\" + modifiedDateTime.Month + modifiedDateTime.ToString(". MMM") + "\\";
                                    if (!Directory.Exists(monthPath))
                                        Directory.CreateDirectory(monthPath);
                                    if (!File.Exists(monthPath + fileInfo.Name))
                                        fileInfo.CopyTo(monthPath + fileInfo.Name);
                                }
                            }
                            #endregion
                            #region DatePath
                            else if (chkMonthFolder && chkDateFolder)
                            {
                                foreach (FileInfo fileInfo in folder.getPictures())
                                {
                                    modifiedDateTime = fileInfo.LastWriteTime;
                                    datePath = folderOutput.FullName + "\\" + modifiedDateTime.Year + "\\" + modifiedDateTime.Month + modifiedDateTime.ToString(". MMM") + "\\" + modifiedDateTime.Day + "\\";
                                    if (!Directory.Exists(datePath))
                                        Directory.CreateDirectory(datePath);
                                    if (!File.Exists(datePath + fileInfo.Name))
                                        fileInfo.CopyTo(datePath + fileInfo.Name);
                                }
                            }
                            #endregion
                        }
                        #endregion
                    }
                    #endregion
                    #region FileNameDate
                    else
                    {
                        #region MoveFiles
                        CultureInfo MyCultureInfo = new CultureInfo("en-US");
                        String dateFormat = textBoxFileNameDateFormat.Text;
                        if (chkMoveFiles)
                        {
                            #region YearPath
                            if (!chkMonthFolder && !chkDateFolder)
                            {
                                foreach (FileInfo fileInfo in folder.getPictures())
                                {
                                    DateTime.TryParseExact(fileInfo.Name.Substring(0, dateFormat.Length), dateFormat, null,
                                            DateTimeStyles.None, out modifiedDateTime);
                                    yearPath = folderOutput.FullName + "\\" + modifiedDateTime.Year + "\\";
                                    if (!Directory.Exists(yearPath))
                                        Directory.CreateDirectory(yearPath);
                                    if (!File.Exists(yearPath + fileInfo.Name))
                                        fileInfo.MoveTo(yearPath + fileInfo.Name);
                                }
                            }
                            #endregion
                            #region MonthPath
                            else if (chkMonthFolder && !chkDateFolder)
                            {
                                foreach (FileInfo fileInfo in folder.getPictures())
                                {
                                    DateTime.TryParseExact(fileInfo.Name.Substring(0, dateFormat.Length), dateFormat, null,
                                             DateTimeStyles.None, out modifiedDateTime);
                                    monthPath = folderOutput.FullName + "\\" + modifiedDateTime.Year + "\\" + modifiedDateTime.Month + modifiedDateTime.ToString(". MMM") + "\\";
                                    if (!Directory.Exists(monthPath))
                                        Directory.CreateDirectory(monthPath);
                                    if (!File.Exists(monthPath + fileInfo.Name))
                                        fileInfo.MoveTo(monthPath + fileInfo.Name);
                                }
                            }
                            #endregion
                            #region DatePath
                            else if (chkMonthFolder && chkDateFolder)
                            {
                                foreach (FileInfo fileInfo in folder.getPictures())
                                {
                                    DateTime.TryParseExact(fileInfo.Name.Substring(0, dateFormat.Length), dateFormat, null,
                                            DateTimeStyles.None, out modifiedDateTime);
                                    datePath = folderOutput.FullName + "\\" + modifiedDateTime.Year + "\\" + modifiedDateTime.Month + modifiedDateTime.ToString(". MMM") + "\\" + modifiedDateTime.Day + "\\";
                                    if (!Directory.Exists(datePath))
                                        Directory.CreateDirectory(datePath);
                                    if (!File.Exists(datePath + fileInfo.Name))
                                        fileInfo.MoveTo(datePath + fileInfo.Name);
                                }
                            }
                            #endregion
                        }
                        #endregion
                        #region CopyFiles
                        else
                        {
                            #region YearPath
                            if (!chkMonthFolder && !chkDateFolder)
                            {
                                foreach (FileInfo fileInfo in folder.getPictures())
                                {
                                    DateTime.TryParseExact(fileInfo.Name.Substring(0, dateFormat.Length), dateFormat, null,
                                            DateTimeStyles.None, out modifiedDateTime);
                                    yearPath = folderOutput.FullName + "\\" + modifiedDateTime.Year + "\\";
                                    if (!Directory.Exists(yearPath))
                                        Directory.CreateDirectory(yearPath);
                                    if (!File.Exists(yearPath + fileInfo.Name))
                                        fileInfo.CopyTo(yearPath + fileInfo.Name);
                                }
                            }
                            #endregion
                            #region MonthPath
                            else if (chkMonthFolder && !chkDateFolder)
                            {
                                foreach (FileInfo fileInfo in folder.getPictures())
                                {
                                    DateTime.TryParseExact(fileInfo.Name.Substring(0, dateFormat.Length), dateFormat, null,
                                            DateTimeStyles.None, out modifiedDateTime);
                                    monthPath = folderOutput.FullName + "\\" + modifiedDateTime.Year + "\\" + modifiedDateTime.Month + modifiedDateTime.ToString(". MMM") + "\\";
                                    if (!Directory.Exists(monthPath))
                                        Directory.CreateDirectory(monthPath);
                                    if (!File.Exists(monthPath + fileInfo.Name))
                                        fileInfo.CopyTo(monthPath + fileInfo.Name);
                                }
                            }
                            #endregion
                            #region DatePath
                            else if (chkMonthFolder && chkDateFolder)
                            {
                                foreach (FileInfo fileInfo in folder.getPictures())
                                {
                                    DateTime.TryParseExact(fileInfo.Name.Substring(0, dateFormat.Length), dateFormat, null,
                                             DateTimeStyles.None, out modifiedDateTime);
                                    datePath = folderOutput.FullName + "\\" + modifiedDateTime.Year + "\\" + modifiedDateTime.Month + modifiedDateTime.ToString(". MMM") + "\\" + modifiedDateTime.Day + "\\";
                                    if (!Directory.Exists(datePath))
                                        Directory.CreateDirectory(datePath);
                                    if (!File.Exists(datePath + fileInfo.Name))
                                        fileInfo.CopyTo(datePath + fileInfo.Name);
                                }
                            }
                            #endregion
                        }
                        #endregion
                    }
                    #endregion
                }
                #endregion
                #region NewNameFile
                else
                {
                    //NewName
                    string newName, newNameValue = newName = textBoxNewName.Text;
                    if (newName.StartsWith("/f"))
                    {
                        int index = newName.LastIndexOf("/f");
                        newNameValue = customDateTime.ToString(newName.Substring(2, index - 2)) + newName.Substring(index + 2);
                    }
                    #region FileMetaDataDate
                    if (!chkFileNameDate)
                    {
                        #region MoveFiles
                        if (chkMoveFiles)
                        {
                            #region YearPath
                            if (!chkMonthFolder && !chkDateFolder)
                            {
                                foreach (FileInfo fileInfo in folder.getPictures())
                                {
                                    modifiedDateTime = fileInfo.LastWriteTime;
                                    yearPath = folderOutput.FullName + "\\" + modifiedDateTime.Year + "\\";
                                    if (!Directory.Exists(yearPath))
                                        Directory.CreateDirectory(yearPath);
                                    if (!File.Exists(yearPath + newNameValue + fileInfo.Extension))
                                        fileInfo.MoveTo(yearPath + newNameValue + fileInfo.Extension);
                                }
                            }
                            #endregion
                            #region MonthPath
                            else if (chkMonthFolder && !chkDateFolder)
                            {
                                foreach (FileInfo fileInfo in folder.getPictures())
                                {
                                    modifiedDateTime = fileInfo.LastWriteTime;
                                    monthPath = folderOutput.FullName + "\\" + modifiedDateTime.Year + "\\" + modifiedDateTime.Month + modifiedDateTime.ToString(". MMM") + "\\";
                                    if (!Directory.Exists(monthPath))
                                        Directory.CreateDirectory(monthPath);
                                    if (!File.Exists(monthPath + newNameValue + fileInfo.Extension))
                                        fileInfo.MoveTo(monthPath + newNameValue + fileInfo.Extension);
                                }
                            }
                            #endregion
                            #region DatePath
                            else if (chkMonthFolder && chkDateFolder)
                            {
                                foreach (FileInfo fileInfo in folder.getPictures())
                                {
                                    modifiedDateTime = fileInfo.LastWriteTime;
                                    datePath = folderOutput.FullName + "\\" + modifiedDateTime.Year + "\\" + modifiedDateTime.Month + modifiedDateTime.ToString(". MMM") + "\\" + modifiedDateTime.Day + "\\";
                                    if (!Directory.Exists(datePath))
                                        Directory.CreateDirectory(datePath);
                                    if (!File.Exists(datePath + newNameValue + fileInfo.Extension))
                                        fileInfo.MoveTo(datePath + newNameValue + fileInfo.Extension);
                                }
                            }
                            #endregion
                        }
                        #endregion
                        #region CopyFiles
                        else
                        {
                            #region YearPath
                            if (!chkMonthFolder && !chkDateFolder)
                            {
                                foreach (FileInfo fileInfo in folder.getPictures())
                                {
                                    modifiedDateTime = fileInfo.LastWriteTime;
                                    yearPath = folderOutput.FullName + "\\" + modifiedDateTime.Year + "\\";
                                    if (!Directory.Exists(yearPath))
                                        Directory.CreateDirectory(yearPath);
                                    if (!File.Exists(yearPath + newNameValue + fileInfo.Extension))
                                        fileInfo.CopyTo(yearPath + newNameValue + fileInfo.Extension);
                                }
                            }
                            #endregion
                            #region Monthpath
                            else if (chkMonthFolder && !chkDateFolder)
                            {
                                foreach (FileInfo fileInfo in folder.getPictures())
                                {
                                    modifiedDateTime = fileInfo.LastWriteTime;
                                    monthPath = folderOutput.FullName + "\\" + modifiedDateTime.Year + "\\" + modifiedDateTime.Month + modifiedDateTime.ToString(". MMM") + "\\";
                                    if (!Directory.Exists(monthPath))
                                        Directory.CreateDirectory(monthPath);
                                    if (!File.Exists(monthPath + newNameValue + fileInfo.Extension))
                                        fileInfo.CopyTo(monthPath + newNameValue + fileInfo.Extension);
                                }
                            }
                            #endregion
                            #region DatePath
                            else if (chkMonthFolder && chkDateFolder)
                            {
                                foreach (FileInfo fileInfo in folder.getPictures())
                                {
                                    modifiedDateTime = fileInfo.LastWriteTime;
                                    datePath = folderOutput.FullName + "\\" + modifiedDateTime.Year + "\\" + modifiedDateTime.Month + modifiedDateTime.ToString(". MMM") + "\\" + modifiedDateTime.Day + "\\";
                                    if (!Directory.Exists(datePath))
                                        Directory.CreateDirectory(datePath);
                                    if (!File.Exists(datePath + newNameValue + fileInfo.Extension))
                                        fileInfo.CopyTo(datePath + newNameValue + fileInfo.Extension);
                                }
                            }
                            #endregion
                        }
                        #endregion
                    }
                    #endregion
                    #region FileNameDate
                    else
                    {
                        #region MoveFiles
                        CultureInfo MyCultureInfo = new CultureInfo("en-US");
                        String dateFormat = textBoxFileNameDateFormat.Text;
                        if (chkMoveFiles)
                        {
                            #region YearPath
                            if (!chkMonthFolder && !chkDateFolder)
                            {
                                foreach (FileInfo fileInfo in folder.getPictures())
                                {
                                    DateTime.TryParseExact(fileInfo.Name.Substring(0, dateFormat.Length), dateFormat, null,
                                            DateTimeStyles.None, out modifiedDateTime);
                                    yearPath = folderOutput.FullName + "\\" + modifiedDateTime.Year + "\\";
                                    if (!Directory.Exists(yearPath))
                                        Directory.CreateDirectory(yearPath);
                                    if (!File.Exists(yearPath + newNameValue + fileInfo.Extension))
                                        fileInfo.MoveTo(yearPath + newNameValue + fileInfo.Extension);
                                }
                            }
                            #endregion
                            #region MonthPath
                            else if (chkMonthFolder && !chkDateFolder)
                            {
                                foreach (FileInfo fileInfo in folder.getPictures())
                                {
                                    DateTime.TryParseExact(fileInfo.Name.Substring(0, dateFormat.Length), dateFormat, null,
                                             DateTimeStyles.None, out modifiedDateTime);
                                    monthPath = folderOutput.FullName + "\\" + modifiedDateTime.Year + "\\" + modifiedDateTime.Month + modifiedDateTime.ToString(". MMM") + "\\";
                                    if (!Directory.Exists(monthPath))
                                        Directory.CreateDirectory(monthPath);
                                    if (!File.Exists(monthPath + newNameValue + fileInfo.Extension))
                                        fileInfo.MoveTo(monthPath + newNameValue + fileInfo.Extension);
                                }
                            }
                            #endregion
                            #region DatePath
                            else if (chkMonthFolder && chkDateFolder)
                            {
                                foreach (FileInfo fileInfo in folder.getPictures())
                                {
                                    DateTime.TryParseExact(fileInfo.Name.Substring(0, dateFormat.Length), dateFormat, null,
                                            DateTimeStyles.None, out modifiedDateTime);
                                    datePath = folderOutput.FullName + "\\" + modifiedDateTime.Year + "\\" + modifiedDateTime.Month + modifiedDateTime.ToString(". MMM") + "\\" + modifiedDateTime.Day + "\\";
                                    if (!Directory.Exists(datePath))
                                        Directory.CreateDirectory(datePath);
                                    if (!File.Exists(datePath + newNameValue + fileInfo.Extension))
                                        fileInfo.MoveTo(datePath + newNameValue + fileInfo.Extension);
                                }
                            }
                            #endregion
                        }
                        #endregion
                        #region CopyFiles
                        else
                        {
                            #region YearPath
                            if (!chkMonthFolder && !chkDateFolder)
                            {
                                foreach (FileInfo fileInfo in folder.getPictures())
                                {
                                    DateTime.TryParseExact(fileInfo.Name.Substring(0, dateFormat.Length), dateFormat, null,
                                            DateTimeStyles.None, out modifiedDateTime);
                                    yearPath = folderOutput.FullName + "\\" + modifiedDateTime.Year + "\\";
                                    if (!Directory.Exists(yearPath))
                                        Directory.CreateDirectory(yearPath);
                                    if (!File.Exists(yearPath + newNameValue + fileInfo.Extension))
                                        fileInfo.CopyTo(yearPath + newNameValue + fileInfo.Extension);
                                }
                            }
                            #endregion
                            #region MonthPath
                            else if (chkMonthFolder && !chkDateFolder)
                            {
                                foreach (FileInfo fileInfo in folder.getPictures())
                                {
                                    DateTime.TryParseExact(fileInfo.Name.Substring(0, dateFormat.Length), dateFormat, null,
                                            DateTimeStyles.None, out modifiedDateTime);
                                    monthPath = folderOutput.FullName + "\\" + modifiedDateTime.Year + "\\" + modifiedDateTime.Month + modifiedDateTime.ToString(". MMM") + "\\";
                                    if (!Directory.Exists(monthPath))
                                        Directory.CreateDirectory(monthPath);
                                    if (!File.Exists(monthPath + newNameValue + fileInfo.Extension))
                                        fileInfo.CopyTo(monthPath + newNameValue + fileInfo.Extension);
                                }
                            }
                            #endregion
                            #region DatePath
                            else if (chkMonthFolder && chkDateFolder)
                            {
                                foreach (FileInfo fileInfo in folder.getPictures())
                                {
                                    DateTime.TryParseExact(fileInfo.Name.Substring(0, dateFormat.Length), dateFormat, null,
                                             DateTimeStyles.None, out modifiedDateTime);
                                    datePath = folderOutput.FullName + "\\" + modifiedDateTime.Year + "\\" + modifiedDateTime.Month + modifiedDateTime.ToString(". MMM") + "\\" + modifiedDateTime.Day + "\\";
                                    if (!Directory.Exists(datePath))
                                        Directory.CreateDirectory(datePath);
                                    if (!File.Exists(datePath + newNameValue + fileInfo.Extension))
                                        fileInfo.CopyTo(datePath + newNameValue + fileInfo.Extension);
                                }
                            }
                            #endregion
                        }
                        #endregion
                    }
                    #endregion
                }
                #endregion
            }
            #endregion
            #region NewDate
            else
            {
                #region NoNewNameFile
                if (!chkFileNewName)
                {
                    #region FileMetaDataDate
                    if (!chkFileNameDate)
                    {
                        #region MoveFiles
                        if (chkMoveFiles)
                        {
                            #region YearPath
                            if (!chkMonthFolder && !chkDateFolder)
                            {
                                foreach (FileInfo fileInfo in folder.getPictures())
                                {
                                    modifiedDateTime = customDateTime;
                                    yearPath = folderOutput.FullName + "\\" + modifiedDateTime.Year + "\\";
                                    if (!Directory.Exists(yearPath))
                                        Directory.CreateDirectory(yearPath);
                                    if (!File.Exists(yearPath + fileInfo.Name))
                                        fileInfo.MoveTo(yearPath + fileInfo.Name);
                                }
                            }
                            #endregion
                            #region MonthPath
                            else if (chkMonthFolder && !chkDateFolder)
                            {
                                foreach (FileInfo fileInfo in folder.getPictures())
                                {
                                    modifiedDateTime = customDateTime;
                                    monthPath = folderOutput.FullName + "\\" + modifiedDateTime.Year + "\\" + modifiedDateTime.Month + modifiedDateTime.ToString(". MMM") + "\\";
                                    if (!Directory.Exists(monthPath))
                                        Directory.CreateDirectory(monthPath);
                                    if (!File.Exists(monthPath + fileInfo.Name))
                                        fileInfo.MoveTo(monthPath + fileInfo.Name);
                                }
                            }
                            #endregion
                            #region DatePath
                            else if (chkMonthFolder && chkDateFolder)
                            {
                                foreach (FileInfo fileInfo in folder.getPictures())
                                {
                                    modifiedDateTime = customDateTime;
                                    datePath = folderOutput.FullName + "\\" + modifiedDateTime.Year + "\\" + modifiedDateTime.Month + modifiedDateTime.ToString(". MMM") + "\\" + modifiedDateTime.Day + "\\";
                                    if (!Directory.Exists(datePath))
                                        Directory.CreateDirectory(datePath);
                                    if (!File.Exists(datePath + fileInfo.Name))
                                        fileInfo.MoveTo(datePath + fileInfo.Name);
                                }
                            }
                            #endregion
                        }
                        #endregion
                        #region CopyFiles
                        else
                        {
                            #region YearPath
                            if (!chkMonthFolder && !chkDateFolder)
                            {
                                foreach (FileInfo fileInfo in folder.getPictures())
                                {
                                    modifiedDateTime = customDateTime;
                                    yearPath = folderOutput.FullName + "\\" + modifiedDateTime.Year + "\\";
                                    if (!Directory.Exists(yearPath))
                                        Directory.CreateDirectory(yearPath);
                                    if (!File.Exists(yearPath + fileInfo.Name))
                                        fileInfo.CopyTo(yearPath + fileInfo.Name);
                                }
                            }
                            #endregion
                            #region Monthpath
                            else if (chkMonthFolder && !chkDateFolder)
                            {
                                foreach (FileInfo fileInfo in folder.getPictures())
                                {
                                    modifiedDateTime = customDateTime;
                                    monthPath = folderOutput.FullName + "\\" + modifiedDateTime.Year + "\\" + modifiedDateTime.Month + modifiedDateTime.ToString(". MMM") + "\\";
                                    if (!Directory.Exists(monthPath))
                                        Directory.CreateDirectory(monthPath);
                                    if (!File.Exists(monthPath + fileInfo.Name))
                                        fileInfo.CopyTo(monthPath + fileInfo.Name);
                                }
                            }
                            #endregion
                            #region DatePath
                            else if (chkMonthFolder && chkDateFolder)
                            {
                                foreach (FileInfo fileInfo in folder.getPictures())
                                {
                                    modifiedDateTime = customDateTime;
                                    datePath = folderOutput.FullName + "\\" + modifiedDateTime.Year + "\\" + modifiedDateTime.Month + modifiedDateTime.ToString(". MMM") + "\\" + modifiedDateTime.Day + "\\";
                                    if (!Directory.Exists(datePath))
                                        Directory.CreateDirectory(datePath);
                                    if (!File.Exists(datePath + fileInfo.Name))
                                        fileInfo.CopyTo(datePath + fileInfo.Name);
                                }
                            }
                            #endregion
                        }
                        #endregion
                    }
                    #endregion
                    #region FileNameDate
                    else
                    {
                        #region MoveFiles
                        CultureInfo MyCultureInfo = new CultureInfo("en-US");
                        String dateFormat = textBoxFileNameDateFormat.Text;
                        if (chkMoveFiles)
                        {
                            #region YearPath
                            if (!chkMonthFolder && !chkDateFolder)
                            {
                                foreach (FileInfo fileInfo in folder.getPictures())
                                {
                                    DateTime.TryParseExact(fileInfo.Name.Substring(0, dateFormat.Length), dateFormat, null,
                                            DateTimeStyles.None, out modifiedDateTime);
                                    yearPath = folderOutput.FullName + "\\" + modifiedDateTime.Year + "\\";
                                    if (!Directory.Exists(yearPath))
                                        Directory.CreateDirectory(yearPath);
                                    if (!File.Exists(yearPath + fileInfo.Name))
                                        fileInfo.MoveTo(yearPath + fileInfo.Name);
                                }
                            }
                            #endregion
                            #region MonthPath
                            else if (chkMonthFolder && !chkDateFolder)
                            {
                                foreach (FileInfo fileInfo in folder.getPictures())
                                {
                                    DateTime.TryParseExact(fileInfo.Name.Substring(0, dateFormat.Length), dateFormat, null,
                                             DateTimeStyles.None, out modifiedDateTime);
                                    monthPath = folderOutput.FullName + "\\" + modifiedDateTime.Year + "\\" + modifiedDateTime.Month + modifiedDateTime.ToString(". MMM") + "\\";
                                    if (!Directory.Exists(monthPath))
                                        Directory.CreateDirectory(monthPath);
                                    if (!File.Exists(monthPath + fileInfo.Name))
                                        fileInfo.MoveTo(monthPath + fileInfo.Name);
                                }
                            }
                            #endregion
                            #region DatePath
                            else if (chkMonthFolder && chkDateFolder)
                            {
                                foreach (FileInfo fileInfo in folder.getPictures())
                                {
                                    DateTime.TryParseExact(fileInfo.Name.Substring(0, dateFormat.Length), dateFormat, null,
                                            DateTimeStyles.None, out modifiedDateTime);
                                    datePath = folderOutput.FullName + "\\" + modifiedDateTime.Year + "\\" + modifiedDateTime.Month + modifiedDateTime.ToString(". MMM") + "\\" + modifiedDateTime.Day + "\\";
                                    if (!Directory.Exists(datePath))
                                        Directory.CreateDirectory(datePath);
                                    if (!File.Exists(datePath + fileInfo.Name))
                                        fileInfo.MoveTo(datePath + fileInfo.Name);
                                }
                            }
                            #endregion
                        }
                        #endregion
                        #region CopyFiles
                        else
                        {
                            #region YearPath
                            if (!chkMonthFolder && !chkDateFolder)
                            {
                                foreach (FileInfo fileInfo in folder.getPictures())
                                {
                                    DateTime.TryParseExact(fileInfo.Name.Substring(0, dateFormat.Length), dateFormat, null,
                                            DateTimeStyles.None, out modifiedDateTime);
                                    yearPath = folderOutput.FullName + "\\" + modifiedDateTime.Year + "\\";
                                    if (!Directory.Exists(yearPath))
                                        Directory.CreateDirectory(yearPath);
                                    if (!File.Exists(yearPath + fileInfo.Name))
                                        fileInfo.CopyTo(yearPath + fileInfo.Name);
                                }
                            }
                            #endregion
                            #region MonthPath
                            else if (chkMonthFolder && !chkDateFolder)
                            {
                                foreach (FileInfo fileInfo in folder.getPictures())
                                {
                                    DateTime.TryParseExact(fileInfo.Name.Substring(0, dateFormat.Length), dateFormat, null,
                                            DateTimeStyles.None, out modifiedDateTime);
                                    monthPath = folderOutput.FullName + "\\" + modifiedDateTime.Year + "\\" + modifiedDateTime.Month + modifiedDateTime.ToString(". MMM") + "\\";
                                    if (!Directory.Exists(monthPath))
                                        Directory.CreateDirectory(monthPath);
                                    if (!File.Exists(monthPath + fileInfo.Name))
                                        fileInfo.CopyTo(monthPath + fileInfo.Name);
                                }
                            }
                            #endregion
                            #region DatePath
                            else if (chkMonthFolder && chkDateFolder)
                            {
                                foreach (FileInfo fileInfo in folder.getPictures())
                                {
                                    DateTime.TryParseExact(fileInfo.Name.Substring(0, dateFormat.Length), dateFormat, null,
                                             DateTimeStyles.None, out modifiedDateTime);
                                    datePath = folderOutput.FullName + "\\" + modifiedDateTime.Year + "\\" + modifiedDateTime.Month + modifiedDateTime.ToString(". MMM") + "\\" + modifiedDateTime.Day + "\\";
                                    if (!Directory.Exists(datePath))
                                        Directory.CreateDirectory(datePath);
                                    if (!File.Exists(datePath + fileInfo.Name))
                                        fileInfo.CopyTo(datePath + fileInfo.Name);
                                }
                            }
                            #endregion
                        }
                        #endregion
                    }
                    #endregion
                }
                #endregion
                #region NewNameFile
                else
                {
                    //NewName
                    string newName, newNameValue = newName = textBoxNewName.Text;
                    if (newName.StartsWith("/f"))
                    {
                        int index = newName.LastIndexOf("/f");
                        newNameValue = customDateTime.ToString(newName.Substring(2, index - 2)) + newName.Substring(index + 2);
                    }
                    #region FileMetaDataDate
                    if (!chkFileNameDate)
                    {
                        #region MoveFiles
                        if (chkMoveFiles)
                        {
                            #region YearPath
                            if (!chkMonthFolder && !chkDateFolder)
                            {
                                foreach (FileInfo fileInfo in folder.getPictures())
                                {
                                    modifiedDateTime = customDateTime;
                                    yearPath = folderOutput.FullName + "\\" + modifiedDateTime.Year + "\\";
                                    if (!Directory.Exists(yearPath))
                                        Directory.CreateDirectory(yearPath);
                                    if (!File.Exists(yearPath + newNameValue + fileInfo.Extension))
                                        fileInfo.MoveTo(yearPath + newNameValue + fileInfo.Extension);
                                    File.SetLastWriteTime(yearPath + newNameValue + fileInfo.Extension, customDateTime);
                                }
                            }
                            #endregion
                            #region MonthPath
                            else if (chkMonthFolder && !chkDateFolder)
                            {
                                foreach (FileInfo fileInfo in folder.getPictures())
                                {
                                    modifiedDateTime = customDateTime;
                                    monthPath = folderOutput.FullName + "\\" + modifiedDateTime.Year + "\\" + modifiedDateTime.Month + modifiedDateTime.ToString(". MMM") + "\\";
                                    if (!Directory.Exists(monthPath))
                                        Directory.CreateDirectory(monthPath);
                                    if (!File.Exists(monthPath + newNameValue + fileInfo.Extension))
                                        fileInfo.MoveTo(monthPath + newNameValue + fileInfo.Extension);
                                    File.SetLastWriteTime(monthPath + newNameValue + fileInfo.Extension, customDateTime);
                                }
                            }
                            #endregion
                            #region DatePath
                            else if (chkMonthFolder && chkDateFolder)
                            {
                                foreach (FileInfo fileInfo in folder.getPictures())
                                {
                                    modifiedDateTime = customDateTime;
                                    datePath = folderOutput.FullName + "\\" + modifiedDateTime.Year + "\\" + modifiedDateTime.Month + modifiedDateTime.ToString(". MMM") + "\\" + modifiedDateTime.Day + "\\";
                                    if (!Directory.Exists(datePath))
                                        Directory.CreateDirectory(datePath);
                                    if (!File.Exists(datePath + newNameValue + fileInfo.Extension))
                                        fileInfo.MoveTo(datePath + newNameValue + fileInfo.Extension);
                                    File.SetLastWriteTime(datePath + newNameValue + fileInfo.Extension, customDateTime);
                                }
                            }
                            #endregion
                        }
                        #endregion
                        #region CopyFiles
                        else
                        {
                            #region YearPath
                            if (!chkMonthFolder && !chkDateFolder)
                            {
                                foreach (FileInfo fileInfo in folder.getPictures())
                                {
                                    modifiedDateTime = customDateTime;
                                    yearPath = folderOutput.FullName + "\\" + modifiedDateTime.Year + "\\";
                                    if (!Directory.Exists(yearPath))
                                        Directory.CreateDirectory(yearPath);
                                    if (!File.Exists(yearPath + newNameValue + fileInfo.Extension))
                                        fileInfo.CopyTo(yearPath + newNameValue + fileInfo.Extension);
                                    File.SetLastWriteTime(yearPath + newNameValue + fileInfo.Extension, customDateTime);
                                }
                            }
                            #endregion
                            #region Monthpath
                            else if (chkMonthFolder && !chkDateFolder)
                            {
                                foreach (FileInfo fileInfo in folder.getPictures())
                                {
                                    modifiedDateTime = customDateTime;
                                    monthPath = folderOutput.FullName + "\\" + modifiedDateTime.Year + "\\" + modifiedDateTime.Month + modifiedDateTime.ToString(". MMM") + "\\";
                                    if (!Directory.Exists(monthPath))
                                        Directory.CreateDirectory(monthPath);
                                    if (!File.Exists(monthPath + newNameValue + fileInfo.Extension))
                                        fileInfo.CopyTo(monthPath + newNameValue + fileInfo.Extension);
                                    File.SetLastWriteTime(monthPath + newNameValue + fileInfo.Extension, customDateTime);
                                }
                            }
                            #endregion
                            #region DatePath
                            else if (chkMonthFolder && chkDateFolder)
                            {
                                foreach (FileInfo fileInfo in folder.getPictures())
                                {
                                    modifiedDateTime = customDateTime;
                                    datePath = folderOutput.FullName + "\\" + modifiedDateTime.Year + "\\" + modifiedDateTime.Month + modifiedDateTime.ToString(". MMM") + "\\" + modifiedDateTime.Day + "\\";
                                    if (!Directory.Exists(datePath))
                                        Directory.CreateDirectory(datePath);
                                    if (!File.Exists(datePath + newNameValue + fileInfo.Extension))
                                        fileInfo.CopyTo(datePath + newNameValue + fileInfo.Extension);
                                    File.SetLastWriteTime(datePath + newNameValue + fileInfo.Extension, customDateTime);
                                }
                            }
                            #endregion
                        }
                        #endregion
                    }
                    #endregion
                    #region FileNameDate
                    else
                    {
                        #region MoveFiles
                        CultureInfo MyCultureInfo = new CultureInfo("en-US");
                        String dateFormat = textBoxFileNameDateFormat.Text;
                        if (chkMoveFiles)
                        {
                            #region YearPath
                            if (!chkMonthFolder && !chkDateFolder)
                            {
                                foreach (FileInfo fileInfo in folder.getPictures())
                                {
                                    DateTime.TryParseExact(fileInfo.Name.Substring(0, dateFormat.Length), dateFormat, null,
                                            DateTimeStyles.None, out modifiedDateTime);
                                    yearPath = folderOutput.FullName + "\\" + modifiedDateTime.Year + "\\";
                                    if (!Directory.Exists(yearPath))
                                        Directory.CreateDirectory(yearPath);
                                    if (!File.Exists(yearPath + newNameValue + fileInfo.Extension))
                                        fileInfo.MoveTo(yearPath + newNameValue + fileInfo.Extension);
                                    File.SetLastWriteTime(yearPath + newNameValue + fileInfo.Extension, customDateTime);
                                }
                            }
                            #endregion
                            #region MonthPath
                            else if (chkMonthFolder && !chkDateFolder)
                            {
                                foreach (FileInfo fileInfo in folder.getPictures())
                                {
                                    DateTime.TryParseExact(fileInfo.Name.Substring(0, dateFormat.Length), dateFormat, null,
                                             DateTimeStyles.None, out modifiedDateTime);
                                    monthPath = folderOutput.FullName + "\\" + modifiedDateTime.Year + "\\" + modifiedDateTime.Month + modifiedDateTime.ToString(". MMM") + "\\";
                                    if (!Directory.Exists(monthPath))
                                        Directory.CreateDirectory(monthPath);
                                    if (!File.Exists(monthPath + newNameValue + fileInfo.Extension))
                                        fileInfo.MoveTo(monthPath + newNameValue + fileInfo.Extension);
                                    File.SetLastWriteTime(monthPath + newNameValue + fileInfo.Extension, customDateTime);
                                }
                            }
                            #endregion
                            #region DatePath
                            else if (chkMonthFolder && chkDateFolder)
                            {
                                foreach (FileInfo fileInfo in folder.getPictures())
                                {
                                    DateTime.TryParseExact(fileInfo.Name.Substring(0, dateFormat.Length), dateFormat, null,
                                            DateTimeStyles.None, out modifiedDateTime);
                                    datePath = folderOutput.FullName + "\\" + modifiedDateTime.Year + "\\" + modifiedDateTime.Month + modifiedDateTime.ToString(". MMM") + "\\" + modifiedDateTime.Day + "\\";
                                    if (!Directory.Exists(datePath))
                                        Directory.CreateDirectory(datePath);
                                    if (!File.Exists(datePath + newNameValue + fileInfo.Extension))
                                        fileInfo.MoveTo(datePath + newNameValue + fileInfo.Extension);
                                    File.SetLastWriteTime(datePath + newNameValue + fileInfo.Extension, customDateTime);
                                }
                            }
                            #endregion
                        }
                        #endregion
                        #region CopyFiles
                        else
                        {
                            #region YearPath
                            if (!chkMonthFolder && !chkDateFolder)
                            {
                                foreach (FileInfo fileInfo in folder.getPictures())
                                {
                                    DateTime.TryParseExact(fileInfo.Name.Substring(0, dateFormat.Length), dateFormat, null,
                                            DateTimeStyles.None, out modifiedDateTime);
                                    yearPath = folderOutput.FullName + "\\" + modifiedDateTime.Year + "\\";
                                    if (!Directory.Exists(yearPath))
                                        Directory.CreateDirectory(yearPath);
                                    if (!File.Exists(yearPath + newNameValue + fileInfo.Extension))
                                        fileInfo.CopyTo(yearPath + newNameValue + fileInfo.Extension);
                                    File.SetLastWriteTime(yearPath + newNameValue + fileInfo.Extension, customDateTime);
                                }
                            }
                            #endregion
                            #region MonthPath
                            else if (chkMonthFolder && !chkDateFolder)
                            {
                                foreach (FileInfo fileInfo in folder.getPictures())
                                {
                                    DateTime.TryParseExact(fileInfo.Name.Substring(0, dateFormat.Length), dateFormat, null,
                                            DateTimeStyles.None, out modifiedDateTime);
                                    monthPath = folderOutput.FullName + "\\" + modifiedDateTime.Year + "\\" + modifiedDateTime.Month + modifiedDateTime.ToString(". MMM") + "\\";
                                    if (!Directory.Exists(monthPath))
                                        Directory.CreateDirectory(monthPath);
                                    if (!File.Exists(monthPath + newNameValue + fileInfo.Extension))
                                        fileInfo.CopyTo(monthPath + newNameValue + fileInfo.Extension);
                                    File.SetLastWriteTime(monthPath + newNameValue + fileInfo.Extension, customDateTime);
                                }
                            }
                            #endregion
                            #region DatePath
                            else if (chkMonthFolder && chkDateFolder)
                            {
                                foreach (FileInfo fileInfo in folder.getPictures())
                                {
                                    DateTime.TryParseExact(fileInfo.Name.Substring(0, dateFormat.Length), dateFormat, null,
                                             DateTimeStyles.None, out modifiedDateTime);
                                    datePath = folderOutput.FullName + "\\" + modifiedDateTime.Year + "\\" + modifiedDateTime.Month + modifiedDateTime.ToString(". MMM") + "\\" + modifiedDateTime.Day + "\\";
                                    if (!Directory.Exists(datePath))
                                        Directory.CreateDirectory(datePath);
                                    if (!File.Exists(datePath + newNameValue + fileInfo.Extension))
                                        fileInfo.CopyTo(datePath + newNameValue + fileInfo.Extension);
                                    File.SetLastWriteTime(datePath + newNameValue + fileInfo.Extension, customDateTime);
                                }
                            }
                            #endregion
                        }
                        #endregion
                    }
                    #endregion
                }
                #endregion
            }
            #endregion
        }
        private String newNameValue(DateTime customDateTime, string format){
            int index = format.LastIndexOf("/f");
            return customDateTime.ToString(format.Substring(2, index - 2)) + format.Substring(index + 2);
                    
        }
        private void buttonSelectOutputFolder_Click(object sender, EventArgs e)
        {
            textBoxOutputFolderPath.Text = folderBrowserDialog.ShowDialog().ToString();
            textBoxOutputFolderPath.Text = folderBrowserDialog.SelectedPath;
        }

        private void checkBoxFileNameDate_CheckedChanged(object sender, EventArgs e)
        {
            textBoxFileNameDateFormat.Enabled = checkBoxFileNameDate.Checked;
        }

        private void buttonAddTag_Click(object sender, EventArgs e)
        {
            listBoxTags.Items.Add(textBoxAddTag.Text);
        }

        private void checkBoxDateFolder_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDateFolder.Checked)
            {
                checkBoxMonthFolder.Checked = true;
                checkBoxMonthFolder.Enabled = false;
            }
            else
                checkBoxMonthFolder.Enabled = true;
        }

        private void radioButtonMoveFiles_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonDateCustom_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonDateCustom.Checked)
                dateTimePicker1.Enabled = true;
            else
                dateTimePicker1.Enabled = false;
        }

        private void checkBoxSetNewDate_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSetNewDate.Checked)
            {
                radioButtonDateCustom.Enabled = true;
                radioButtonDateReadFromFile.Enabled = true;
                if (!checkBoxFileNameDate.Checked)
                {
                    radioButtonDateReadFromFile.Checked = false;
                    radioButtonDateCustom.Checked = true;
                }
                if (radioButtonDateCustom.Checked)
                    dateTimePicker1.Enabled = true;
            }
            else
            {
                dateTimePicker1.Enabled = false;
                radioButtonDateCustom.Enabled = false;
                radioButtonDateReadFromFile.Enabled = false;
            }
        }

        private void radioButtonDateReadFromFile_CheckedChanged(object sender, EventArgs e)
        {
            //if (radioButtonDateReadFromFile.Checked)
            //{
            //    if (!checkBoxFileNameDate.Checked)
            //    {
            //        radioButtonDateReadFromFile.Checked = false;
            //        radioButtonDateCustom.Checked = true;
            //    }
            //}
        }

        private void checkBoxNewName_CheckedChanged(object sender, EventArgs e)
        {
            textBoxNewName.Enabled = checkBoxNewName.Checked;
        }
    }
}
