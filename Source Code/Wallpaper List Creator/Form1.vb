Imports System
Imports System.IO
Imports System.Collections


Public Class Main_Program
    Inherits System.Windows.Forms.Form

    Dim inputtedpath As String
    Dim recordcounter As Integer
    Dim selecteddrive As String
    Dim selectedpath As String
    Private Selected_Database As String
    Private Selected_Table As String

    Dim filenamelist As New System.Collections.ArrayList()

    Dim checklistset As Integer
    Dim maxchecklistset As Integer

    Public Structure MyFileItem
        Public FilenameString As String
        Public SizeString As String
        Public CheckedStatus As Boolean
    End Structure

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        selectedpath = ""
        selecteddrive = ""
        recordcounter = 0
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If Disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(Disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents CheckedListBox1 As System.Windows.Forms.CheckedListBox
    Friend WithEvents Display_Path As System.Windows.Forms.CheckBox
    Friend WithEvents Display_Extension As System.Windows.Forms.CheckBox
    Friend WithEvents display_foldernames As System.Windows.Forms.CheckBox
    Friend WithEvents refresh_button As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Display_Size As System.Windows.Forms.CheckBox
    Friend WithEvents Select_Database_Dialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ParentPath As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Datasource As System.Windows.Forms.Label
    Friend WithEvents Columns As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox()
        Me.Display_Path = New System.Windows.Forms.CheckBox()
        Me.Display_Extension = New System.Windows.Forms.CheckBox()
        Me.display_foldernames = New System.Windows.Forms.CheckBox()
        Me.refresh_button = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Display_Size = New System.Windows.Forms.CheckBox()
        Me.Select_Database_Dialog = New System.Windows.Forms.OpenFileDialog()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.ParentPath = New System.Windows.Forms.Label()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Columns = New System.Windows.Forms.Label()
        Me.Datasource = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(24, 32)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(96, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Select Folder"
        Me.ToolTip1.SetToolTip(Me.Button1, "Allows you to select the folder that will be recursively searched")
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.HorizontalScrollbar = True
        Me.CheckedListBox1.Location = New System.Drawing.Point(40, 88)
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(656, 199)
        Me.CheckedListBox1.Sorted = True
        Me.CheckedListBox1.TabIndex = 6
        Me.CheckedListBox1.TabStop = False
        '
        'Display_Path
        '
        Me.Display_Path.Location = New System.Drawing.Point(272, 48)
        Me.Display_Path.Name = "Display_Path"
        Me.Display_Path.Size = New System.Drawing.Size(88, 24)
        Me.Display_Path.TabIndex = 3
        Me.Display_Path.Text = "Display Path"
        Me.ToolTip1.SetToolTip(Me.Display_Path, "Display the full filepath in search results")
        '
        'Display_Extension
        '
        Me.Display_Extension.Location = New System.Drawing.Point(272, 24)
        Me.Display_Extension.Name = "Display_Extension"
        Me.Display_Extension.Size = New System.Drawing.Size(120, 24)
        Me.Display_Extension.TabIndex = 2
        Me.Display_Extension.Text = "Display Extension"
        Me.ToolTip1.SetToolTip(Me.Display_Extension, "Display the file extension in all search results")
        '
        'display_foldernames
        '
        Me.display_foldernames.Location = New System.Drawing.Point(392, 24)
        Me.display_foldernames.Name = "display_foldernames"
        Me.display_foldernames.Size = New System.Drawing.Size(136, 24)
        Me.display_foldernames.TabIndex = 4
        Me.display_foldernames.Text = "Include Folder Names"
        Me.ToolTip1.SetToolTip(Me.display_foldernames, "Include folder names in search")
        '
        'refresh_button
        '
        Me.refresh_button.Enabled = False
        Me.refresh_button.Location = New System.Drawing.Point(144, 32)
        Me.refresh_button.Name = "refresh_button"
        Me.refresh_button.TabIndex = 1
        Me.refresh_button.Text = "Refresh List"
        Me.ToolTip1.SetToolTip(Me.refresh_button, "Refreshes the search results")
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(400, 296)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(296, 16)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "0 records displayed"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.Label1, "The number of results resulting from the search")
        '
        'Display_Size
        '
        Me.Display_Size.Location = New System.Drawing.Point(392, 48)
        Me.Display_Size.Name = "Display_Size"
        Me.Display_Size.Size = New System.Drawing.Size(112, 24)
        Me.Display_Size.TabIndex = 5
        Me.Display_Size.Text = "Display File Size"
        Me.ToolTip1.SetToolTip(Me.Display_Size, "Dislpay the file size of each file in search")
        '
        'Button2
        '
        Me.Button2.Enabled = False
        Me.Button2.Location = New System.Drawing.Point(24, 40)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(112, 23)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Select Database"
        Me.ToolTip1.SetToolTip(Me.Button2, "Allows you to select a database to which the results will be sent to")
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Location = New System.Drawing.Point(168, 16)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(504, 144)
        Me.Panel1.TabIndex = 9
        '
        'Button3
        '
        Me.Button3.Enabled = False
        Me.Button3.Location = New System.Drawing.Point(24, 32)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(112, 23)
        Me.Button3.TabIndex = 8
        Me.Button3.Text = "Update Database"
        Me.ToolTip1.SetToolTip(Me.Button3, "Allows you to update the selected database")
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button5, Me.display_foldernames, Me.Display_Path, Me.Button1, Me.refresh_button, Me.Display_Extension, Me.Display_Size, Me.ParentPath, Me.Button6, Me.Button9})
        Me.GroupBox1.Location = New System.Drawing.Point(24, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(688, 336)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Step 1 - Select Files"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(672, 80)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(8, 8)
        Me.Button5.TabIndex = 15
        Me.Button5.TabStop = False
        Me.ToolTip1.SetToolTip(Me.Button5, "Select none")
        '
        'ParentPath
        '
        Me.ParentPath.Location = New System.Drawing.Point(16, 312)
        Me.ParentPath.Name = "ParentPath"
        Me.ParentPath.Size = New System.Drawing.Size(656, 16)
        Me.ParentPath.TabIndex = 8
        Me.ParentPath.Text = "Parent Path: "
        Me.ToolTip1.SetToolTip(Me.ParentPath, "The path selected on which to search")
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(672, 96)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(8, 8)
        Me.Button6.TabIndex = 16
        Me.Button6.TabStop = False
        Me.ToolTip1.SetToolTip(Me.Button6, "Select all")
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(672, 176)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(8, 8)
        Me.Button9.TabIndex = 19
        Me.Button9.TabStop = False
        Me.ToolTip1.SetToolTip(Me.Button9, "Show Next")
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.Columns, Me.Panel1, Me.Button2, Me.Datasource})
        Me.GroupBox2.Location = New System.Drawing.Point(24, 352)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(688, 192)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Step 2 - Select a Data Source"
        '
        'Columns
        '
        Me.Columns.Location = New System.Drawing.Point(584, 168)
        Me.Columns.Name = "Columns"
        Me.Columns.Size = New System.Drawing.Size(88, 16)
        Me.Columns.TabIndex = 15
        Me.Columns.Text = "0 Columns"
        Me.Columns.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Datasource
        '
        Me.Datasource.Location = New System.Drawing.Point(16, 168)
        Me.Datasource.Name = "Datasource"
        Me.Datasource.Size = New System.Drawing.Size(568, 16)
        Me.Datasource.TabIndex = 14
        Me.Datasource.Text = "Data Source: "
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button4, Me.RichTextBox1, Me.Button3})
        Me.GroupBox3.Location = New System.Drawing.Point(24, 552)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(688, 144)
        Me.GroupBox3.TabIndex = 14
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Step 3 - Update the Database"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(672, 16)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(8, 8)
        Me.Button4.TabIndex = 9
        Me.Button4.TabStop = False
        Me.ToolTip1.SetToolTip(Me.Button4, "Clear Textbox")
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(168, 16)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ReadOnly = True
        Me.RichTextBox1.Size = New System.Drawing.Size(504, 120)
        Me.RichTextBox1.TabIndex = 11
        Me.RichTextBox1.TabStop = False
        Me.RichTextBox1.Text = ""
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(696, 152)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(8, 8)
        Me.Button7.TabIndex = 17
        Me.Button7.TabStop = False
        Me.ToolTip1.SetToolTip(Me.Button7, "Show Previous")
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(696, 168)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(8, 8)
        Me.Button8.TabIndex = 18
        Me.Button8.TabStop = False
        Me.ToolTip1.SetToolTip(Me.Button8, "Show All")
        '
        'Main_Program
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(736, 696)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button8, Me.Button7, Me.Label1, Me.CheckedListBox1, Me.GroupBox1, Me.GroupBox2, Me.GroupBox3})
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(744, 730)
        Me.MinimumSize = New System.Drawing.Size(744, 730)
        Me.Name = "Main_Program"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manga CD List Generator"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region



    Public Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim frm_Select_Folder_Dialog As New Select_Folder_Dialog()
        If Not selecteddrive.Equals("") Then
            frm_Select_Folder_Dialog.Activate()
            frm_Select_Folder_Dialog.DriveListBox1.Drive = selecteddrive
            frm_Select_Folder_Dialog.DirListBox1.Path = selectedpath
            frm_Select_Folder_Dialog.old_drive = selecteddrive
            frm_Select_Folder_Dialog.old_path = selectedpath
            frm_Select_Folder_Dialog.TextBox1.Text = selectedpath
        End If
        Try
            frm_Select_Folder_Dialog.ShowDialog()
        Catch et As Exception
            MsgBox(et.Message)
        End Try
        If Not frm_Select_Folder_Dialog.TextBox1.Text = "" Then
            CheckedListBox1.Items.Clear()
            CheckedListBox1.Update()
            filenamelist.Clear()
            'sizelist.Clear()
            ProcessPath(frm_Select_Folder_Dialog.TextBox1.Text)
            maxchecklistset = filenamelist.Count() / 200 + 1
            checklistset = 1
            displaychecklistset(checklistset)
            inputtedpath = frm_Select_Folder_Dialog.TextBox1.Text
            selectedpath = frm_Select_Folder_Dialog.DirListBox1.Path
            selecteddrive = frm_Select_Folder_Dialog.DriveListBox1.Drive
            'CheckedListBox1.Update()
            refresh_button.Enabled = True
            Button2.Enabled = True
        End If
        frm_Select_Folder_Dialog.Dispose()
    End Sub


    Public Sub ProcessPath(ByVal inputpath As String)
        Dim path As String
        ParentPath.Text = "Parent Path: "
        recordcounter = 0
        path = inputpath
        If File.Exists(path) Then
            ' This path is a file
            ProcessFile(path)
        Else
            If Directory.Exists(path) Then
                ' This path is a directory
                ProcessDirectory(path)
            Else
                MsgBox(path & " is not a valid file or directory.")
            End If
        End If
        Label1.Text = recordcounter & " records displayed"
        ParentPath.Text = ParentPath.Text & path
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

        If display_foldernames.Checked = True Then
            ProcessFileD(targetDirectory)
        End If

        For Each fileName In fileEntries
            tempfilename = Directory.GetParent(fileName)
            filesize = Math.Round(((FileLen(fileName) / 1024) / 1024), 2)
            If Display_Path.Checked = False Then
                fileName = Replace(fileName, tempfilename.FullName, "")
                fileName = Replace(fileName, "\", "")
            End If
            If Display_Extension.Checked = False Then
                tempextension = 0
                tempextension = fileName.LastIndexOf(".")
                If tempextension > 0 Then
                    fileName = fileName.Remove(tempextension, (fileName.Length - tempextension))
                End If
            End If
            If Display_Size.Checked = True Then
                If filesize > 99 Then
                    filesize = Math.Round(filesize, 0)
                End If
                If filesize < 1 Then
                    filesize = Math.Round(filesize * 1024, 2)
                    filesize_string = filesize & "KB"
                Else
                    filesize_string = filesize & "MB"
                End If
                'fileName = fileName & filesize_string
            End If
            If Display_Size.Checked = True Then
                ProcessFile(fileName, filesize_string)
            Else
                ProcessFile(fileName)
            End If
        Next fileName
        Dim subdirectoryEntries As String() = Directory.GetDirectories(targetDirectory)
        ' Recurse into subdirectories of this directory
        Dim subdirectory As String
        For Each subdirectory In subdirectoryEntries
            ProcessDirectory(subdirectory)
        Next subdirectory

    End Sub 'ProcessDirectory

    ' Real logic for processing found files would go here.
    Public Sub ProcessFile(ByVal path As String)
        recordcounter = recordcounter + 1
        'CheckedListBox1.Items.Add(path, True)
        Dim itemtoadd As MyFileItem
        itemtoadd.FilenameString = path
        itemtoadd.CheckedStatus = True
        itemtoadd.SizeString = ""
        'filenamelist.Add(itemtoadd)
        SortedArraylistInsert(itemtoadd)
    End Sub 'ProcessFile

    Public Sub ProcessFileD(ByVal path As String)
        recordcounter = recordcounter + 1
        'CheckedListBox1.Items.Add(path, True)
        Dim itemtoadd As MyFileItem
        itemtoadd.FilenameString = path
        itemtoadd.CheckedStatus = True
        If Display_Size.Checked = True Then
            Dim foldersize As Long = GetFolderSize(path)
            foldersize = Math.Round(((foldersize / 1024) / 1024), 2)
            If foldersize > 99 Then
                foldersize = Math.Round(foldersize, 0)
            End If
            If foldersize < 1 Then
                foldersize = Math.Round(foldersize * 1024, 2)
                itemtoadd.SizeString = foldersize & "KB"
            Else
                itemtoadd.SizeString = foldersize & "MB"
            End If
        Else
            itemtoadd.SizeString = ""
        End If
        'filenamelist.Add(itemtoadd)
        SortedArraylistInsert(itemtoadd)
    End Sub 'ProcessFile

    Public Sub ProcessFile(ByVal path As String, ByVal sizestr As String)
        recordcounter = recordcounter + 1
        'CheckedListBox1.Items.Add(path & "    [" & sizestr & "]", True)
        Dim itemtoadd As MyFileItem
        itemtoadd.FilenameString = path
        itemtoadd.CheckedStatus = True
        itemtoadd.SizeString = sizestr
        'filenamelist.Add(itemtoadd)
        SortedArraylistInsert(itemtoadd)
    End Sub 'ProcessFile

    Public Function displaychecklistset(ByVal setnumber As Integer)
        CheckedListBox1.Items.Clear()
        Dim startcount As Integer
        Dim endcount As Integer
        If Not setnumber = 0 Then
            startcount = (setnumber - 1) * 200
            If filenamelist.Count() - 1 >= startcount + 200 Then
                endcount = startcount + 200
            Else
                endcount = filenamelist.Count()
            End If

            Dim runner As Integer
            Dim itemtoadd As MyFileItem
            For runner = startcount To endcount - 1
                itemtoadd = filenamelist.Item(runner)
                If Display_Size.Checked = True Then
                    CheckedListBox1.Items.Add(itemtoadd.FilenameString & "    [" & itemtoadd.SizeString & "]", itemtoadd.CheckedStatus)
                Else
                    CheckedListBox1.Items.Add(itemtoadd.FilenameString, itemtoadd.CheckedStatus)
                End If
            Next
            CheckedListBox1.Update()
            Label1.Text = (startcount + 1) & " to " & (endcount) & " of " & filenamelist.Count() & " records displayed"
        Else
            startcount = 0
            endcount = filenamelist.Count() - 1


            Dim runner As Integer
            Dim itemtoadd As MyFileItem
            For runner = startcount To endcount
                itemtoadd = filenamelist.Item(runner)
                If Display_Size.Checked = True Then
                    CheckedListBox1.Items.Add(itemtoadd.FilenameString & "    [" & itemtoadd.SizeString & "]", itemtoadd.CheckedStatus)
                Else
                    CheckedListBox1.Items.Add(itemtoadd.FilenameString, itemtoadd.CheckedStatus)
                End If
            Next
            CheckedListBox1.Update()
            Label1.Text = (startcount + 1) & " to " & (endcount + 1) & " of " & filenamelist.Count() & " records displayed"
        End If

    End Function


    Private Sub refresh_button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles refresh_button.Click
        filenamelist.Clear()

        If Not inputtedpath.Equals("") Then
            CheckedListBox1.Items.Clear()
            CheckedListBox1.Update()
            ProcessPath(inputtedpath)
            'CheckedListBox1.Update()
            maxchecklistset = filenamelist.Count() / 200 + 1
            checklistset = 1
            displaychecklistset(checklistset)
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        DialogResult = Select_Database_Dialog.ShowDialog()
        If DialogResult = DialogResult.OK Or DialogResult = DialogResult.Yes Then

            Try
                Selected_Database = Select_Database_Dialog.FileName


                Dim Conn As Data.OleDb.OleDbConnection = New Data.OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Selected_Database & ";")
                Conn.Open()
                Dim schemaTable As DataTable = Conn.GetOleDbSchemaTable(Data.OleDb.OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, Nothing, "TABLE"})

                Dim frm_Select_Table_Dialog As New Select_Table_Dialog()
                frm_Select_Table_Dialog.Activate()
                frm_Select_Table_Dialog.TableChoice = schemaTable
                frm_Select_Table_Dialog.ShowDialog()
                Dim tableresult As String = frm_Select_Table_Dialog.Selected_Table.SelectedItem.ToString
                Selected_Table = tableresult
                frm_Select_Table_Dialog.Dispose()
                Dim schemaTable2 As DataTable = Conn.GetOleDbSchemaTable(Data.OleDb.OleDbSchemaGuid.Columns, New Object() {Nothing, Nothing, tableresult, Nothing})

                Dim myRow2 As DataRow
                Dim myCol2 As DataColumn

                Panel1.Controls.Clear()

                RichTextBox1.Clear()

                Dim ordinal As Integer
                Dim columnname As String
                Dim datatype As OleDb.OleDbType
                For Each myRow2 In schemaTable2.Rows
                    ordinal = 0
                    columnname = ""


                    For Each myCol2 In schemaTable2.Columns
                        If myCol2.ColumnName = "DATA_TYPE" Then
                            datatype = myRow2(myCol2)
                        End If
                        If myCol2.ColumnName = "COLUMN_NAME" Then
                            columnname = myRow2(myCol2).ToString()
                        End If
                        If myCol2.ColumnName = "ORDINAL_POSITION" Then
                            ordinal = Val(myRow2(myCol2).ToString())
                        End If
                    Next
                    ordinal = ordinal - 1
                    If Not columnname.Equals("") Then
                        'MsgBox(myRow2(myCol2).ToString())
                        Dim LabelMiniMe As New System.Windows.Forms.Label()
                        LabelMiniMe.Location = New System.Drawing.Point(0, (ordinal * 24))
                        LabelMiniMe.Name = "Label_" & columnname
                        LabelMiniMe.Size = New System.Drawing.Size(136, 16)
                        LabelMiniMe.Text = columnname
                        Panel1.Controls.Add(LabelMiniMe)
                        LabelMiniMe.Visible = True

                        Dim ComboBoxMiniMe As New System.Windows.Forms.ComboBox()
                        ComboBoxMiniMe.Location = New System.Drawing.Point(140, (ordinal * 24))
                        ComboBoxMiniMe.Name = "ComboBox_" & columnname
                        ComboBoxMiniMe.Size = New System.Drawing.Size(136, 16)
                        If datatype.ToString().ToLower = "wchar" Then
                            ComboBoxMiniMe.Text = "'" & columnname & "'"
                            ComboBoxMiniMe.Items.Add("Selected Item String")
                            If Display_Size.Checked = True Then
                                ComboBoxMiniMe.Items.Add("File Size String")
                            End If

                        Else
                            ComboBoxMiniMe.Text = columnname

                        End If
                        ComboBoxMiniMe.Items.Add("Ignore Column")
                        Panel1.Controls.Add(ComboBoxMiniMe)
                        ComboBoxMiniMe.Visible = True
                        If datatype.ToString().ToLower = "boolean" Then
                            ComboBoxMiniMe.Items.Add(1)
                            ComboBoxMiniMe.Items.Add(0)
                            ComboBoxMiniMe.SelectedIndex = 0
                            ComboBoxMiniMe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
                        End If

                        Dim LabelMiniM2 As New System.Windows.Forms.Label()
                        LabelMiniM2.Location = New System.Drawing.Point(280, (ordinal * 24))
                        LabelMiniM2.Name = "Label_TYPE_" & columnname
                        LabelMiniM2.Size = New System.Drawing.Size(50, 16)
                        LabelMiniM2.Text = datatype.ToString()
                        Panel1.Controls.Add(LabelMiniM2)
                        LabelMiniM2.Visible = True

                    End If
                Next
                Conn.Close()
                Button3.Enabled = True
                Datasource.Text = "Data Source: " & Selected_Database & "      Table: " & Selected_Table
                Columns.Text = (Panel1.Controls.Count / 3) & " Columns"
            Catch dberror As OleDb.OleDbException
                MsgBox("Cannot Connect to the Datasource Specified" & vbCrLf & dberror.Message)

            Catch othererror As Exception
                MsgBox("Error encountered" & vbCrLf & othererror.Message)
            End Try
        End If
    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        Try
            Dim Conn As Data.OleDb.OleDbConnection = New Data.OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Selected_Database & ";")
            Conn.Open()
            Dim counter As Integer
            Dim itemtoadd As MyFileItem
            Dim stoppedflag As Boolean = False
            For counter = 0 To filenamelist.Count - 1
                itemtoadd = filenamelist.Item(counter)
                If itemtoadd.CheckedStatus = True Then
                    Try
                        Dim sqlstr As String
                        sqlstr = "insert into " & Selected_Table & "("
                        Dim runne As Integer
                        For runne = 0 To Panel1.Controls.Count - 1 Step 3
                            If Not Panel1.Controls(runne + 1).Text = "Ignore Column" Then
                                sqlstr = sqlstr & Panel1.Controls(runne).Text & ","
                            End If
                        Next
                        sqlstr = sqlstr.Remove(sqlstr.Length - 1, 1)

                        sqlstr = sqlstr & ") values ("
                        Dim runner As Integer
                        For runner = 1 To Panel1.Controls.Count - 1 Step 3
                            If Panel1.Controls(runner).Text = "Selected Item String" Then
                                'Dim itemtoadd As MyFileItem
                                'itemtoadd = filenamelist.Item(counter)
                                If itemtoadd.CheckedStatus = True Then
                                    sqlstr = sqlstr & "'" & itemtoadd.FilenameString.Replace("'", "`") & "',"
                                End If
                            Else
                                If Panel1.Controls(runner).Text = "File Size String" Then
                                    'Dim itemtoadd As MyFileItem
                                    'itemtoadd = filenamelist.Item(counter)
                                    If itemtoadd.CheckedStatus = True Then
                                        sqlstr = sqlstr & "'" & itemtoadd.SizeString & "',"
                                    End If

                                Else
                                    If Not Panel1.Controls(runner).Text = "Ignore Column" Then
                                        sqlstr = sqlstr & Panel1.Controls(runner).Text & ","
                                    End If
                                End If
                            End If
                        Next
                        sqlstr = sqlstr.Remove(sqlstr.Length - 1, 1)
                        sqlstr = sqlstr & ")"
                        RichTextBox1.Text = RichTextBox1.Text & sqlstr & vbCrLf

                        Dim recset As Data.OleDb.OleDbCommand = New Data.OleDb.OleDbCommand(sqlstr, Conn)
                        recset.ExecuteNonQuery()
                    Catch sqlerror As Exception
                        Dim answer As Microsoft.VisualBasic.MsgBoxResult = MsgBox("Cannot update the datbase" & vbCrLf & sqlerror.Message, MsgBoxStyle.OKCancel)
                        If answer = MsgBoxResult.Abort Or answer = MsgBoxResult.Cancel Then
                            MsgBox("Stopping further updates to the Database")
                            stoppedflag = True
                            Exit For
                        End If
                    End Try
                End If
            Next


            Conn.Close()
            If stoppedflag = False Then
                MsgBox("Database Successfully Updated")
            End If
        Catch dberror As OleDb.OleDbException
            MsgBox("Cannot Connect to the Datasource Specified" & vbCrLf & dberror.Message)
        Catch othererror As Exception
            MsgBox("Error encountered" & vbCrLf & othererror.Message)
        End Try

    End Sub

    Private Sub checkedlistbox1_doubleclick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckedListBox1.DoubleClick
        CheckedListBox1_SelectedIndexChanged(sender, e)
    End Sub


    Private Sub checkedlistbox1_keydown(ByVal sender As System.Object, ByVal keyselected As System.Windows.Forms.KeyEventArgs) Handles CheckedListBox1.KeyDown

        Dim selnum As Integer = CheckedListBox1.SelectedIndex()
        If selnum >= 0 Then
            If keyselected.KeyCode = Keys.F2 And keyselected.KeyData = Keys.F2 Then

                Dim frm_Change_FileString_Dialog As New Change_FileString_Dialog()
                frm_Change_FileString_Dialog.Activate()
                Dim runner As Integer
                Dim stringtotest As String
                Dim resulted As Integer
                Dim itemtoadd As MyFileItem

                CheckedListBox1.Sorted = False

                For runner = 0 To filenamelist.Count() - 1
                    stringtotest = CheckedListBox1.SelectedItem()
                    If Display_Size.Checked Then
                        resulted = stringtotest.LastIndexOf("[")
                        stringtotest = stringtotest.Remove(resulted, stringtotest.Length - resulted)
                    End If
                    stringtotest = stringtotest.TrimEnd


                    itemtoadd = filenamelist.Item(runner)
                    If itemtoadd.FilenameString = stringtotest Then
                        frm_Change_FileString_Dialog.oldstring.Text = itemtoadd.FilenameString
                        frm_Change_FileString_Dialog.newstring.Text = itemtoadd.FilenameString
                        Exit For
                    End If

                Next


                Try
                    frm_Change_FileString_Dialog.ShowDialog()
                Catch et As Exception
                    MsgBox(et.Message)
                End Try

                If Not frm_Change_FileString_Dialog.newstring.Text = "" Then
                    itemtoadd.FilenameString = frm_Change_FileString_Dialog.newstring.Text
                    filenamelist.Item(runner) = itemtoadd

                    CheckedListBox1.Items.RemoveAt(selnum)
                    'CheckedListBox1.Items.Add(itemtoadd.FilenameString, True)
                    'CheckedListBox1.SelectedIndex = CheckedListBox1.Items.Count - 1
                    'Dim checktest As Boolean = CheckedListBox1.GetItemChecked(selnum)
                    If Display_Size.Checked = True Then
                        CheckedListBox1.Items.Insert(selnum, itemtoadd.FilenameString & "    [" & itemtoadd.SizeString & "]")
                    Else
                        CheckedListBox1.Items.Insert(selnum, itemtoadd.FilenameString)
                    End If

                    If itemtoadd.CheckedStatus = True Then
                        CheckedListBox1.SetItemChecked(selnum, True)
                    Else
                        CheckedListBox1.SetItemChecked(selnum, False)
                    End If

                    'CheckedListBox1.Update()
                    'CheckedListBox1.SelectedValue = itemtoadd.FilenameString
                    ' CheckedListBox1.Items.Item(selnum) = frm_Change_FileString_Dialog.newstring.Text
                    ' MsgBox(CheckedListBox1.Items.Item(selnum))
                    'CheckedListBox1.SelectedIndex = selnum
                    'CheckedListBox1.Focus()
                End If
                frm_Change_FileString_Dialog.Dispose()

            End If
        End If

        keyselected.Handled = True
    End Sub

    Private Sub CheckedListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckedListBox1.SelectedValueChanged
        Dim selnum As Integer = CheckedListBox1.SelectedIndex()
        Dim runner As Integer
        Dim stringtotest As String
        Dim resulted As Integer
        If selnum >= 0 Then
            For runner = 0 To filenamelist.Count() - 1
                stringtotest = CheckedListBox1.SelectedItem()
                If Display_Size.Checked Then
                    resulted = stringtotest.LastIndexOf("[")
                    stringtotest = stringtotest.Remove(resulted, stringtotest.Length - resulted)
                End If
                stringtotest = stringtotest.TrimEnd
                If CheckedListBox1.GetItemChecked(selnum) = False Then
                    Dim itemtoadd As MyFileItem
                    itemtoadd = filenamelist.Item(runner)
                    If itemtoadd.FilenameString = stringtotest Then
                        'MsgBox("Removed: " & stringtotest)
                        itemtoadd.CheckedStatus = False
                        filenamelist.Item(runner) = itemtoadd
                        'filenamelist.RemoveAt(runner)
                        'If sizelist.Count > 0 Then
                        'sizelist.RemoveAt(runner)
                        'End If
                        Exit For

                    End If
                Else
                    Dim itemtoadd As MyFileItem
                    itemtoadd = filenamelist.Item(runner)
                    If itemtoadd.FilenameString = stringtotest Then
                        ' MsgBox("Added: " & stringtotest)
                        itemtoadd.CheckedStatus = True
                        filenamelist.Item(runner) = itemtoadd
                        'filenamelist.RemoveAt(runner)
                        'If sizelist.Count > 0 Then
                        'sizelist.RemoveAt(runner)
                        'End If
                        Exit For

                    End If
                End If

            Next
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        RichTextBox1.Clear()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim runner As Integer
        For runner = 0 To filenamelist.Count() - 1
            Dim itemtoadd As MyFileItem
            itemtoadd = filenamelist.Item(runner)
            itemtoadd.CheckedStatus = False
            filenamelist.Item(runner) = itemtoadd
        Next
        For runner = 0 To CheckedListBox1.Items.Count() - 1
            CheckedListBox1.SetItemChecked(runner, False)
        Next
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim runner As Integer
        For runner = 0 To filenamelist.Count() - 1
            Dim itemtoadd As MyFileItem
            itemtoadd = filenamelist.Item(runner)
            itemtoadd.CheckedStatus = True
            filenamelist.Item(runner) = itemtoadd
        Next
        For runner = 0 To CheckedListBox1.Items.Count() - 1
            CheckedListBox1.SetItemChecked(runner, True)
        Next

        '************************************************************************************
        'ArraylistSort(filenamelist)
        '***************************************************************************************
    End Sub

    'Public Function ArraylistSort(ByVal inputarraylist As System.Collections.ArrayList)
    '   outputarraylist.Clear()
    '  Dim runner As Integer
    ' Dim itemtoadd As MyFileItem
    ''MsgBox("here")
    'For runner = 0 To inputarraylist.Count() - 1

    '   itemtoadd = inputarraylist.Item(runner)
    '  ArraylistSortSub(1, outputarraylist.Count(), itemtoadd)
    'Next
    'inputarraylist = outputarraylist
    'For runner = 0 To inputarraylist.Count() - 1
    '   itemtoadd = outputarraylist.Item(runner)
    '  RichTextBox1.Text = RichTextBox1.Text & itemtoadd.FilenameString & vbCrLf
    'Next
    'End Function

    'Protected Function ArraylistSortSub(ByVal segstart As Integer, ByVal segend As Integer, ByVal itemtoinput As MyFileItem)
    'MsgBox("now")
    'RichTextBox1.Text = RichTextBox1.Text & segstart & "  " & segend & vbCrLf
    '   If filenamelist.Count() = 0 Then
    '      filenamelist.Add(itemtoinput)
    ' Else
    '   Dim itemtocheckagainst As New MyFileItem()
    '    If segstart = segend Then
    '      itemtocheckagainst = filenamelist.Item(segstart - 1)
    '     Dim result As Integer = String.Compare(itemtoinput.FilenameString, itemtocheckagainst.FilenameString)
    '    If result = 0 Or result < 0 Then
    '       filenamelist.Insert(segstart - 1, itemtoinput)
    '  End If
    ' If result > 0 Then
    '    filenamelist.Insert(segstart, itemtoinput)
    'End If
    'Else
    'Dim midpoint As Integer
    'midpoint = (segend - segstart + 1) / 2 + 1
    'itemtocheckagainst = filenamelist.Item(midpoint - 1)
    'Dim result2 As Integer = String.Compare(itemtoinput.FilenameString, itemtocheckagainst.FilenameString)
    'If result2 = 0 Or result2 < 0 Then
    'ArraylistSortSub(segstart, midpoint - 1, itemtoinput)
    'End If
    'If result2 > 0 Then
    'ArraylistSortSub(midpoint + 1, segend, itemtoinput)
    'End If

    'End If


    'End If
    'End Function

    Protected Function SortedArraylistInsert(ByVal itemtoinput As MyFileItem)
        Dim insertflag As Boolean = False
        Dim runner = New Integer()
        Dim itemtocheckagainst As MyFileItem

        If filenamelist.Count() = 0 Then
            filenamelist.Add(itemtoinput)
            'MsgBox(itemtoinput.FilenameString)
            insertflag = True
        End If
        If insertflag = False Then
            If filenamelist.Count() = 1 Then
                itemtocheckagainst = filenamelist.Item(0)
                If String.Compare(itemtoinput.FilenameString, itemtocheckagainst.FilenameString) <= 0 Then
                    filenamelist.Insert(0, itemtoinput)
                    'MsgBox("insert" & itemtoinput.FilenameString)
                Else
                    filenamelist.Add(itemtoinput)
                    'MsgBox("add" & itemtoinput.FilenameString)
                End If
                insertflag = True
            End If
        End If

        '        If insertflag = False Then
        '       If filenamelist.Count() > 1 And filenamelist.Count() < 4 Then
        '          Dim check1 As Boolean
        '         Dim check2 As Boolean
        '        For runner = 0 To filenamelist.Count() - 2
        '           check1 = False
        '          check2 = False
        '         itemtocheckagainst = filenamelist.Item(runner)
        '        If String.Compare(itemtoinput.FilenameString, itemtocheckagainst.FilenameString) >= 0 Then
        '           check1 = True
        '      End If
        '     itemtocheckagainst = filenamelist.Item(runner + 1)
        'If String.Compare(itemtoinput.FilenameString, itemtocheckagainst.FilenameString) <= 0 Then
        'check2 = True
        '       End If
        '      If check2 = True And check1 = True Then
        'filenamelist.Insert(runner, itemtoinput)
        'insertflag = True
        'Exit For
        '       End If
        '  Next

        'End If
        'End If

        If insertflag = False Then
            Dim midpoint As Integer
            midpoint = filenamelist.Count() Mod 2
            If midpoint = 0 Then
                midpoint = filenamelist.Count() \ 2
            Else
                midpoint = filenamelist.Count() \ 2 + 1
            End If
            'Dim seg1midpoint As Integer
            'seg1midpoint = midpoint Mod 2
            'If seg1midpoint = 0 Then
            'seg1midpoint = midpoint \ 2
            'Else
            '   seg1midpoint = midpoint \ 2 + 1
            'End If
            'Dim seg2midpoint As Integer
            'seg2midpoint = (filenamelist.Count() - midpoint + 1) Mod 2
            'If seg2midpoint = 0 Then
            'seg2midpoint = (filenamelist.Count() - midpoint + 1) \ 2
            'Else
            'seg2midpoint = (filenamelist.Count() - midpoint + 1) \ 2 + 1
            'End If

            Dim segment As Integer

            itemtocheckagainst = filenamelist.Item(filenamelist.Count() - 1)
            Dim result5 As Integer = String.Compare(itemtoinput.FilenameString, itemtocheckagainst.FilenameString)
            '       itemtocheckagainst = filenamelist.Item(seg2midpoint - 1)
            '      Dim result4 As Integer = String.Compare(itemtoinput.FilenameString, itemtocheckagainst.FilenameString)
            itemtocheckagainst = filenamelist.Item(midpoint - 1)
            Dim result3 As Integer = String.Compare(itemtoinput.FilenameString, itemtocheckagainst.FilenameString)
            '     itemtocheckagainst = filenamelist.Item(seg1midpoint - 1)
            '    Dim result2 As Integer = String.Compare(itemtoinput.FilenameString, itemtocheckagainst.FilenameString)
            itemtocheckagainst = filenamelist.Item(0)
            Dim result1 As Integer = String.Compare(itemtoinput.FilenameString, itemtocheckagainst.FilenameString)

            If result1 <= 0 Or result3 = 0 Or result5 >= 0 Then
                If result1 <= 0 And insertflag = False Then
                    filenamelist.Insert(0, itemtoinput)
                    insertflag = True
                End If
                'If result2 = 0 And insertflag = False Then
                '   filenamelist.Insert(seg1midpoint - 1, itemtoinput)
                '  insertflag = True
                'End If

                'If result4 = 0 And insertflag = False Then
                'filenamelist.Insert(seg2midpoint - 1, itemtoinput)
                'insertflag = True
                'End If
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
                'If result2 < 0 Then
                '   segment = 1
                'End If
                'If result4 > 0 Then
                'segment = 4
                'End If
                'If result4 < 0 And result3 > 0 Then
                'segment = 3
                'End If
                'If result2 > 0 And result3 < 0 Then
                '   segment = 2
                'End If
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
                'If segment = 3 Then

                'For runner = midpoint - 1 To seg2midpoint - 1
                '  check1 = False
                '   check2 = False
                ' itemtocheckagainst = filenamelist.Item(runner)
                'If String.Compare(itemtoinput.FilenameString, itemtocheckagainst.FilenameString) >= 0 Then
                '   check1 = True
                'End If
                'itemtocheckagainst = filenamelist.Item(runner + 1)
                'If String.Compare(itemtoinput.FilenameString, itemtocheckagainst.FilenameString) <= 0 Then
                'check2 = True
                'End If
                'If check2 = True And check1 = True And insertflag = False Then
                'filenamelist.Insert(runner, itemtoinput)
                'insertflag = True
                'Exit For
                'End If
                'Next
                'End If
                'If segment = 4 Then

                '                For runner = seg2midpoint - 1 To filenamelist.Count() - 1
                '                   check1 = False
                '                  check2 = False
                '                 itemtocheckagainst = filenamelist.Item(runner)
                '                If String.Compare(itemtoinput.FilenameString, itemtocheckagainst.FilenameString) >= 0 Then
                '                   check1 = True
                '              End If
                '             itemtocheckagainst = filenamelist.Item(runner + 1)
                '            If String.Compare(itemtoinput.FilenameString, itemtocheckagainst.FilenameString) <= 0 Then
                '               check2 = True
                '          End If
                '         If check2 = True And check1 = True And insertflag = False Then
                '            filenamelist.Insert(runner, itemtoinput)
                '           insertflag = True
                '          Exit For
                '     End If
                'Next
                'End If
            End If

        End If
        If insertflag = False Then
            MsgBox("Alert - Nothing was entered into the arraylist")
        Else
            'Dim runner2 As Integer
            'For runner2 = 0 To filenamelist.Count() - 1
            'Dim itemtoadd As MyFileItem
            'itemtoadd = filenamelist.Item(runner2)
            'RichTextBox1.Text = RichTextBox1.Text & itemtoadd.FilenameString & "   "
            'Next
            'RichTextBox1.Text = RichTextBox1.Text & vbCrLf
        End If
    End Function


    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        checklistset = 0
        displaychecklistset(checklistset)
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        checklistset = checklistset - 1
        If checklistset <= 0 Then checklistset = 1
        displaychecklistset(checklistset)
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        checklistset = checklistset + 1
        'MsgBox("max: " & maxchecklistset)
        'MsgBox("current: " & checklistset)
        If checklistset >= maxchecklistset Then checklistset = maxchecklistset
        'MsgBox("max: " & maxchecklistset)
        'MsgBox("current: " & checklistset)
        displaychecklistset(checklistset)
    End Sub

    Function GetFolderSize(ByVal DirPath As String, _
    Optional ByVal IncludeSubFolders As Boolean = True) As Long

        Dim lngDirSize As Long
        Dim objFileInfo As FileInfo
        Dim objDir As DirectoryInfo = New DirectoryInfo(DirPath)
        Dim objSubFolder As DirectoryInfo

        Try

            'add length of each file
            For Each objFileInfo In objDir.GetFiles()
                lngDirSize += objFileInfo.Length
            Next

            'call recursively to get sub folders
            'if you don't want this set optional
            'parameter to false 
            If IncludeSubFolders Then
                For Each objSubFolder In objDir.GetDirectories()
                    lngDirSize += GetFolderSize(objSubFolder.FullName)
                Next
            End If

        Catch Ex As Exception


        End Try

        Return lngDirSize
    End Function

    Private Sub Display_Path_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Display_Path.CheckedChanged

    End Sub
    Private Sub Display_Size_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Display_Size.CheckedChanged

    End Sub
    Private Sub Display_Extension_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Display_Extension.CheckedChanged

    End Sub
    Private Sub display_foldernames_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles display_foldernames.CheckedChanged

    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class