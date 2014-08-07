Imports System
Imports System.IO
Imports System.Collections


Public Class Main_Program
    Inherits System.Windows.Forms.Form

    'Global variables
    Dim inputtedpath As String 'holds the path of the currently selected folder
    Dim recordcounter As Integer 'global counter for the number of image files located
    Dim imagesize As Integer 'global counter for the total size of all located images
    Dim filenamelist As New System.Collections.ArrayList 'container for the filenames harvested for insertion

    'Global structures

    Public Structure MyFileItem 'structure used in the filenamelist container. Created for file sorting purposes
        Public FilenameString As String 'file name
        Public FullPathString As String 'full file path
    End Structure

    'Constructor function
    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        'initialises the global variables (attributes)
        recordcounter = 0
        inputtedpath = ""
        imagesize = 0
    End Sub

#Region " Windows Form Designer generated code "
    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents refresh_button As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ParentPath As System.Windows.Forms.Label
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents recursivesearch As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents includebmp As System.Windows.Forms.CheckBox
    Friend WithEvents includegif As System.Windows.Forms.CheckBox
    Friend WithEvents includejpg As System.Windows.Forms.CheckBox
    Friend WithEvents totalfiles As System.Windows.Forms.Label
    Friend WithEvents totalfilesizelabel As System.Windows.Forms.Label
    Friend WithEvents fileoutput As System.Windows.Forms.Label
    Friend WithEvents frm_Select_Folder_Dialog As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Generate_List_Button As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents includepng As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Main_Program))
        Me.Generate_List_Button = New System.Windows.Forms.Button
        Me.refresh_button = New System.Windows.Forms.Button
        Me.totalfiles = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.fileoutput = New System.Windows.Forms.Label
        Me.totalfilesizelabel = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.includepng = New System.Windows.Forms.CheckBox
        Me.includebmp = New System.Windows.Forms.CheckBox
        Me.includegif = New System.Windows.Forms.CheckBox
        Me.includejpg = New System.Windows.Forms.CheckBox
        Me.recursivesearch = New System.Windows.Forms.CheckBox
        Me.ParentPath = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.frm_Select_Folder_Dialog = New System.Windows.Forms.FolderBrowserDialog
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Generate_List_Button
        '
        Me.Generate_List_Button.BackColor = System.Drawing.Color.Orange
        Me.Generate_List_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Generate_List_Button.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Generate_List_Button.Location = New System.Drawing.Point(16, 40)
        Me.Generate_List_Button.Name = "Generate_List_Button"
        Me.Generate_List_Button.Size = New System.Drawing.Size(96, 23)
        Me.Generate_List_Button.TabIndex = 0
        Me.Generate_List_Button.Text = "Generate List"
        Me.ToolTip1.SetToolTip(Me.Generate_List_Button, "Generate the wallpaper list from a selected folder's contents")
        '
        'refresh_button
        '
        Me.refresh_button.BackColor = System.Drawing.Color.Orange
        Me.refresh_button.Enabled = False
        Me.refresh_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.refresh_button.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.refresh_button.Location = New System.Drawing.Point(120, 40)
        Me.refresh_button.Name = "refresh_button"
        Me.refresh_button.Size = New System.Drawing.Size(88, 23)
        Me.refresh_button.TabIndex = 1
        Me.refresh_button.Text = "Refresh List"
        Me.ToolTip1.SetToolTip(Me.refresh_button, "Refresh the last generated wallpaper list using the same path as previously selec" & _
        "ted")
        '
        'totalfiles
        '
        Me.totalfiles.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.totalfiles.Location = New System.Drawing.Point(104, 104)
        Me.totalfiles.Name = "totalfiles"
        Me.totalfiles.Size = New System.Drawing.Size(352, 16)
        Me.totalfiles.TabIndex = 6
        Me.totalfiles.Text = "N/A"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.fileoutput)
        Me.GroupBox1.Controls.Add(Me.totalfilesizelabel)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.recursivesearch)
        Me.GroupBox1.Controls.Add(Me.Generate_List_Button)
        Me.GroupBox1.Controls.Add(Me.refresh_button)
        Me.GroupBox1.Controls.Add(Me.ParentPath)
        Me.GroupBox1.Controls.Add(Me.totalfiles)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(24, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(624, 216)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Wallpaper List Creator Control Block"
        '
        'Label6
        '
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(568, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 16)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "About"
        Me.ToolTip1.SetToolTip(Me.Label6, "The root path from which the wallpaper list is generated")
        '
        'Label4
        '
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(16, 152)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 16)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Output File:"
        Me.ToolTip1.SetToolTip(Me.Label4, "The path of the generated wallpaper list")
        '
        'Label3
        '
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(16, 128)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 16)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Size of Images:"
        Me.ToolTip1.SetToolTip(Me.Label3, "The combined size of all the image files in the generated wallpaper list")
        '
        'Label2
        '
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(16, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 16)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "No. Images:"
        Me.ToolTip1.SetToolTip(Me.Label2, "The total number of images included in the generated wallpaper list")
        '
        'Label1
        '
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(16, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Source Folder:"
        Me.ToolTip1.SetToolTip(Me.Label1, "The root path from which the wallpaper list is generated")
        '
        'fileoutput
        '
        Me.fileoutput.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.fileoutput.Location = New System.Drawing.Point(104, 152)
        Me.fileoutput.Name = "fileoutput"
        Me.fileoutput.Size = New System.Drawing.Size(352, 16)
        Me.fileoutput.TabIndex = 16
        Me.fileoutput.Text = "N/A"
        '
        'totalfilesizelabel
        '
        Me.totalfilesizelabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.totalfilesizelabel.Location = New System.Drawing.Point(104, 128)
        Me.totalfilesizelabel.Name = "totalfilesizelabel"
        Me.totalfilesizelabel.Size = New System.Drawing.Size(352, 16)
        Me.totalfilesizelabel.TabIndex = 15
        Me.totalfilesizelabel.Text = "N/A"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.includepng)
        Me.GroupBox2.Controls.Add(Me.includebmp)
        Me.GroupBox2.Controls.Add(Me.includegif)
        Me.GroupBox2.Controls.Add(Me.includejpg)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.White
        Me.GroupBox2.Location = New System.Drawing.Point(464, 48)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(136, 128)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Included File Types"
        Me.ToolTip1.SetToolTip(Me.GroupBox2, "This allows you to specify which type of image files are to be included in the se" & _
        "arch")
        '
        'includepng
        '
        Me.includepng.Checked = True
        Me.includepng.CheckState = System.Windows.Forms.CheckState.Checked
        Me.includepng.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.includepng.Location = New System.Drawing.Point(16, 96)
        Me.includepng.Name = "includepng"
        Me.includepng.TabIndex = 15
        Me.includepng.Text = "PNG"
        '
        'includebmp
        '
        Me.includebmp.Checked = True
        Me.includebmp.CheckState = System.Windows.Forms.CheckState.Checked
        Me.includebmp.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.includebmp.Location = New System.Drawing.Point(16, 48)
        Me.includebmp.Name = "includebmp"
        Me.includebmp.TabIndex = 14
        Me.includebmp.Text = "BMP"
        '
        'includegif
        '
        Me.includegif.Checked = True
        Me.includegif.CheckState = System.Windows.Forms.CheckState.Checked
        Me.includegif.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.includegif.Location = New System.Drawing.Point(16, 72)
        Me.includegif.Name = "includegif"
        Me.includegif.TabIndex = 13
        Me.includegif.Text = "GIF"
        '
        'includejpg
        '
        Me.includejpg.Checked = True
        Me.includejpg.CheckState = System.Windows.Forms.CheckState.Checked
        Me.includejpg.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.includejpg.Location = New System.Drawing.Point(16, 24)
        Me.includejpg.Name = "includejpg"
        Me.includejpg.TabIndex = 12
        Me.includejpg.Text = "JPG"
        '
        'recursivesearch
        '
        Me.recursivesearch.Checked = True
        Me.recursivesearch.CheckState = System.Windows.Forms.CheckState.Checked
        Me.recursivesearch.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.recursivesearch.Location = New System.Drawing.Point(480, 184)
        Me.recursivesearch.Name = "recursivesearch"
        Me.recursivesearch.Size = New System.Drawing.Size(120, 24)
        Me.recursivesearch.TabIndex = 12
        Me.recursivesearch.Text = "Recursive Search"
        Me.ToolTip1.SetToolTip(Me.recursivesearch, "This option allows for including subfolders in the wallpaper list generation proc" & _
        "ess")
        '
        'ParentPath
        '
        Me.ParentPath.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ParentPath.Location = New System.Drawing.Point(104, 80)
        Me.ParentPath.Name = "ParentPath"
        Me.ParentPath.Size = New System.Drawing.Size(352, 16)
        Me.ParentPath.TabIndex = 8
        Me.ParentPath.Text = "N/A"
        '
        'Label5
        '
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(533, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 16)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Help |"
        Me.ToolTip1.SetToolTip(Me.Label5, "The root path from which the wallpaper list is generated")
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.DefaultExt = "wpl"
        Me.SaveFileDialog1.FileName = "untitled.wpl"
        Me.SaveFileDialog1.Filter = "Wallpaper Lists|*.wpl|All files|*.*"
        Me.SaveFileDialog1.RestoreDirectory = True
        Me.SaveFileDialog1.Title = "Save Wallpaper List As..."
        '
        'frm_Select_Folder_Dialog
        '
        Me.frm_Select_Folder_Dialog.ShowNewFolderButton = False
        '
        'Main_Program
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.DarkOrange
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(672, 246)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(680, 280)
        Me.MinimumSize = New System.Drawing.Size(680, 280)
        Me.Name = "Main_Program"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Wallpaper List Creator 2.0"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    'Handles clicking the Generate List Button. Starts the process of generating the wallpaper list file (.wpl)
    Public Sub Generate_List_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Generate_List_Button.Click
        Try
            'Create a Browse folder dialog

            'bug in open folder dialog means we have to manually set the text to be displayed
            frm_Select_Folder_Dialog.Description = "Select the root folder from which the wallpaper list is to be generated from."
            'Open the select folder dialog
            Dim result As DialogResult
            result = frm_Select_Folder_Dialog.ShowDialog()

            'if the user selected a folder then process the path. Else, simply dispose of the browse folder dialog to free up resources.
            If result = DialogResult.OK Then
                'get the selected path
                inputtedpath = frm_Select_Folder_Dialog.SelectedPath
                'dispose of the form
                frm_Select_Folder_Dialog.Dispose()
                'clear the filenamelist container
                filenamelist.Clear()
                'enable the ability to refresh the last wallpaper list generation
                refresh_button.Enabled = True
                'run the actual process to generate the wallpaper list
                ProcessPath(inputtedpath)
            Else
                'dispose of the form
                frm_Select_Folder_Dialog.Dispose()
            End If
        Catch et As Exception
            'handle any exception with a simple msgbox
            MsgBox(et.Message, MsgBoxStyle.Exclamation, "Wallpaper List Creator 2.0")
        End Try
    End Sub


    Public Sub ProcessPath(ByVal inputpath As String)
        Dim path As String
        recordcounter = 0
        path = inputpath
        If Directory.Exists(path) Then
            ' This path is a directory
            ProcessDirectory(path)
            totalfiles.Text = recordcounter & " files"
            ParentPath.Text = path
            ToolTip1.SetToolTip(ParentPath, path)

            Dim foldersize As Long = imagesize
            If foldersize < 1024 Then
                totalfilesizelabel.Text = foldersize & " Bytes"
            End If
            If foldersize >= 1024 And foldersize < 1048576 Then
                foldersize = Math.Round((foldersize / 1024), 2)
                totalfilesizelabel.Text = foldersize & " KB"
            End If
            If foldersize >= 1048576 And foldersize < 1073741824 Then
                foldersize = Math.Round(((foldersize / 1024) / 1024), 2)
                totalfilesizelabel.Text = foldersize & " MB"
            End If
            If foldersize >= 1073741824 Then
                foldersize = Math.Round((((foldersize / 1024) / 1024) / 1024), 2)
                totalfilesizelabel.Text = foldersize & " GB"
            End If
            CreateFile()
        Else
            MsgBox(path & " is not a valid file or directory.")
        End If

    End Sub 'Main


    ' Process all files in the directory passed in, and recurse on any directories 
    ' that are found to process the files they contain
    Public Sub ProcessDirectory(ByVal targetDirectory As String)
        Dim fileEntries As String() = Directory.GetFiles(targetDirectory)
        ' Process the list of files found in the directory
        Dim fileName As String
        Dim tempfilename As System.IO.DirectoryInfo
        Dim tempextension As Integer
        Dim filesize As Decimal
        Dim filesize_string As String
        Dim fullpathfilename As String
        For Each fileName In fileEntries
            tempfilename = Directory.GetParent(fileName)
            fullpathfilename = fileName
            filesize = Math.Round(((FileLen(fileName) / 1024) / 1024), 2)

            fileName = Replace(fileName, tempfilename.FullName, "")
            fileName = Replace(fileName, "\", "")

            tempextension = 0
            tempextension = fileName.LastIndexOf(".")
            If tempextension > 0 Then
                fileName = fileName.Remove(tempextension, (fileName.Length - tempextension))
            End If


            If ((includejpg.Checked = True) And (fullpathfilename.EndsWith("jpg") Or fullpathfilename.EndsWith("JPG"))) Then
                ProcessFile(fileName, fullpathfilename)
            End If
            If ((includebmp.Checked = True) And (fullpathfilename.EndsWith("bmp") Or fullpathfilename.EndsWith("BMP"))) Then
                ProcessFile(fileName, fullpathfilename)
            End If
            If ((includegif.Checked = True) And (fullpathfilename.EndsWith("gif") Or fullpathfilename.EndsWith("GIF"))) Then
                ProcessFile(fileName, fullpathfilename)
            End If
            If ((includepng.Checked = True) And (fullpathfilename.EndsWith("png") Or fullpathfilename.EndsWith("PNG"))) Then
                ProcessFile(fileName, fullpathfilename)
            End If

        Next fileName

        If recursivesearch.Checked = True Then
            Dim subdirectoryEntries As String() = Directory.GetDirectories(targetDirectory)
            ' Recurse into subdirectories of this directory
            Dim subdirectory As String
            For Each subdirectory In subdirectoryEntries
                ProcessDirectory(subdirectory)
            Next subdirectory
        End If

    End Sub 'ProcessDirectory

    Public Sub ProcessFile(ByVal path As String, ByVal sizestr As String)
        recordcounter += 1
        imagesize += GetImageSize(sizestr)
        'CheckedListBox1.Items.Add(path & "    [" & sizestr & "]", True)
        Dim itemtoadd As MyFileItem
        itemtoadd.FilenameString = path
        'itemtoadd.CheckedStatus = True
        itemtoadd.FullPathString = sizestr
        'filenamelist.Add(itemtoadd)
        SortedArraylistInsert(itemtoadd)
    End Sub 'ProcessFile

    Private Sub refresh_button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles refresh_button.Click
        filenamelist.Clear()

        If Not inputtedpath.Equals("") Then

            ProcessPath(inputtedpath)

        End If
    End Sub


    Protected Function SortedArraylistInsert(ByVal itemtoinput As MyFileItem)
        Dim insertflag As Boolean = False
        Dim runner = New Integer
        Dim itemtocheckagainst As MyFileItem

        If filenamelist.Count() = 0 Then
            filenamelist.Add(itemtoinput)

            insertflag = True
        End If
        If insertflag = False Then
            If filenamelist.Count() = 1 Then
                itemtocheckagainst = filenamelist.Item(0)
                If String.Compare(itemtoinput.FilenameString, itemtocheckagainst.FilenameString) <= 0 Then
                    filenamelist.Insert(0, itemtoinput)

                Else
                    filenamelist.Add(itemtoinput)

                End If
                insertflag = True
            End If
        End If



        If insertflag = False Then
            Dim midpoint As Integer
            midpoint = filenamelist.Count() Mod 2
            If midpoint = 0 Then
                midpoint = filenamelist.Count() \ 2
            Else
                midpoint = filenamelist.Count() \ 2 + 1
            End If


            Dim segment As Integer

            itemtocheckagainst = filenamelist.Item(filenamelist.Count() - 1)
            Dim result5 As Integer = String.Compare(itemtoinput.FilenameString, itemtocheckagainst.FilenameString)

            itemtocheckagainst = filenamelist.Item(midpoint - 1)
            Dim result3 As Integer = String.Compare(itemtoinput.FilenameString, itemtocheckagainst.FilenameString)

            itemtocheckagainst = filenamelist.Item(0)
            Dim result1 As Integer = String.Compare(itemtoinput.FilenameString, itemtocheckagainst.FilenameString)

            If result1 <= 0 Or result3 = 0 Or result5 >= 0 Then
                If result1 <= 0 And insertflag = False Then
                    filenamelist.Insert(0, itemtoinput)
                    insertflag = True
                End If

                If result5 >= 0 And insertflag = False Then
                    filenamelist.Add(itemtoinput)
                    insertflag = True
                End If
                If result3 = 0 And insertflag = False Then
                    filenamelist.Insert(midpoint - 1, itemtoinput)
                    insertflag = True
                End If
            End If
            If insertflag = False Then

                If result3 < 0 Then segment = 1 Else segment = 2
                Dim check1 As Boolean
                Dim check2 As Boolean
                If segment = 1 Then

                    For runner = 0 To midpoint - 1
                        check1 = False
                        check2 = False
                        itemtocheckagainst = filenamelist.Item(runner)
                        If String.Compare(itemtoinput.FilenameString, itemtocheckagainst.FilenameString) >= 0 Then
                            check1 = True
                        End If
                        itemtocheckagainst = filenamelist.Item(runner + 1)
                        If String.Compare(itemtoinput.FilenameString, itemtocheckagainst.FilenameString) <= 0 Then
                            check2 = True
                        End If
                        If check2 = True And check1 = True And insertflag = False Then
                            filenamelist.Insert(runner + 1, itemtoinput)
                            insertflag = True
                            Exit For
                        End If
                    Next
                End If
                If segment = 2 Then

                    For runner = midpoint - 1 To filenamelist.Count() - 2
                        check1 = False
                        check2 = False
                        itemtocheckagainst = filenamelist.Item(runner)
                        If String.Compare(itemtoinput.FilenameString, itemtocheckagainst.FilenameString) >= 0 Then
                            check1 = True
                        End If
                        itemtocheckagainst = filenamelist.Item(runner + 1)
                        If String.Compare(itemtoinput.FilenameString, itemtocheckagainst.FilenameString) <= 0 Then
                            check2 = True
                        End If
                        If check2 = True And check1 = True And insertflag = False Then
                            filenamelist.Insert(runner + 1, itemtoinput)
                            insertflag = True
                            Exit For
                        End If
                    Next
                End If

            End If

        End If
        If insertflag = False Then
            MsgBox("Alert - Nothing was entered into the arraylist")
        Else

        End If
    End Function


    Function GetImageSize(ByVal DirPath As String) As Long
        Dim lngDirSize As Long
        Dim objFileInfo As FileInfo = New FileInfo(DirPath)

        Try
            lngDirSize += objFileInfo.Length
        Catch Ex As Exception
        End Try
        Return lngDirSize
    End Function





    Private Sub CreateFile()
        Try
            Dim result As DialogResult
            result = SaveFileDialog1.ShowDialog
            If result = DialogResult.OK Then

                Dim stg As String = SaveFileDialog1.FileName

                Dim filemanipulator2 = New System.IO.FileInfo(stg)
                If filemanipulator2.Exists = True Then
                    filemanipulator2.Delete()
                End If

                Dim objStreamWriter = New System.IO.StreamWriter(stg)

                '******************************************************************************
                Dim itemtoadd As MyFileItem
                Dim counter As Integer
                For counter = 0 To filenamelist.Count - 1
                    itemtoadd = filenamelist.Item(counter)

                    objStreamWriter.WriteLine(itemtoadd.FullPathString)

                Next


                '*******************************************************

                objStreamWriter.Close()
                fileoutput.Text = SaveFileDialog1.FileName
                ToolTip1.SetToolTip(fileoutput, SaveFileDialog1.FileName)
                '    ' Tell user the operation is over and close the file.
                MsgBox("The wallpaper list has been successfully generated.", MsgBoxStyle.OKOnly, "Wallpaper List Creator 2.0")
                SaveFileDialog1.Dispose()
            End If
        Catch et As Exception
            MsgBox(et.Message, MsgBoxStyle.Exclamation, "Wallpaper List Creator 2.0")
        End Try
    End Sub


    Private Sub Main_Program_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Generate_List_Button.Enabled = True
        refresh_button.Enabled = False
    End Sub


    Private Sub About_Screen_Display(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click
        Try
            Dim aboutscreen As New About
            Dim result As DialogResult
            result = aboutscreen.ShowDialog()
            aboutscreen.Dispose()
        Catch et As Exception
            MsgBox(et.Message, MsgBoxStyle.Exclamation, "Wallpaper List Creator 2.0")
        End Try
    End Sub

    Private Sub Help_Screen_Display(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click
        Try
            Dim helpscreen As New Help
            Dim result As DialogResult
            result = helpscreen.ShowDialog()
            helpscreen.Dispose()
        Catch et As Exception
            MsgBox(et.Message, MsgBoxStyle.Exclamation, "Wallpaper List Creator 2.0")
        End Try
    End Sub
End Class