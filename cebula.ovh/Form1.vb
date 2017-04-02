Imports System.Threading
Imports System.Text.RegularExpressions

Module InvokeWebBrowser

    <Runtime.CompilerServices.Extension()>
    Public Sub InvokeCustom(ByVal Control As Control, ByVal Action As Action)
        If Control.InvokeRequired Then Control.Invoke(New MethodInvoker(Sub() Action()), Nothing) Else Action.Invoke()
    End Sub

End Module

Public Class Form1
    Declare Sub Sleep Lib "kernel32.dll" (ByVal Milliseconds As Integer)

    Private ThreadBrowse, ThreadAutoMode As Thread
    Dim aTimer As Timers.Timer
    Private _WaitHandle_FirstThreadDone As New System.Threading.AutoResetEvent(False)

    Public QuietMode As Boolean = False
    Public PubFilePath As String = ""

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub StartNavigate()
        ThreadBrowse = New Thread(AddressOf Cebula_Upload)
        ThreadBrowse.Name = "StartNavigate"
        ThreadBrowse.SetApartmentState(ApartmentState.STA)

        ThreadBrowse.Start()
        'ThreadBrowse.Join()
        'Return
    End Sub
    Function GetFileName(FullFilePath As String) As String
        Dim FileName As String = ""
        Dim SplitStr As String()

        If InStr(FullFilePath, "\") Then
            SplitStr = Split(FullFilePath, "\")
            FileName = SplitStr(UBound(SplitStr))
        Else
            FileName = FullFilePath
        End If

        Return FileName
    End Function
    Private Sub Cebula_Upload()
        Me.Invoke(DirectCast(Sub() ProgBar_Status.Value = ProgBar_Status.Minimum, MethodInvoker))
        Dim IsFinish As Boolean = False
        Dim WebBro As WebBrowser = myBrowser
        Dim address As String = "http://cebula.ovh/upload/index.php"

        WebBro.AllowNavigation = True
        WebBro.Navigate(New Uri(address))

        Do Until IsFinish = True
            Thread.Sleep(100)
            WebBro.InvokeCustom(Sub() IsFinish = (WebBro.ReadyState = WebBrowserReadyState.Complete))
        Loop
        Me.Invoke(DirectCast(Sub() lbl_Status.Text = "Status: Connected to website.", MethodInvoker))
        Dim getCebula As HtmlElementCollection = Nothing
        Dim foundInputFile As Integer = -1
        Dim foundInputSend As Integer = -1
        Dim foundInputLink As Integer = -1
        Dim uploadedLink As String


        Dim totalfilesInt As Integer = 0
        Dim totalfilesOut As Integer = 0
        Dim percentageBar As Double
        Me.Invoke(DirectCast(Sub() totalfilesInt = LB_Pending.Items.Count, MethodInvoker))

        Dim shownFileName As String


        For j = 0 To totalfilesInt - 1
            Me.Invoke(DirectCast(Sub() PubFilePath = LB_Pending.Items(j).ToString, MethodInvoker))
            shownFileName = GetFileName(PubFilePath)
            Me.Invoke(DirectCast(Sub() lbl_Status.Text = "Status: Uploading file " & shownFileName, MethodInvoker))

            Do Until IsFinish = True
                Thread.Sleep(100)
                WebBro.InvokeCustom(Sub() IsFinish = (WebBro.ReadyState = WebBrowserReadyState.Complete))
            Loop

            getCebula = Nothing

            Do While IsNothing(getCebula)
                Thread.Sleep(100)
                WebBro.InvokeCustom(Sub() getCebula = WebBro.Document.GetElementsByTagName("input"))
            Loop

            For i = 0 To getCebula.Count - 1

                If getCebula(i).GetAttribute("type") = "file" Then
                    foundInputFile = i
                End If
                If getCebula(i).GetAttribute("type") = "submit" Then
                    foundInputSend = i
                End If
            Next

            aTimer = New Timers.Timer
            AddHandler aTimer.Elapsed, AddressOf OnTimedEvent
            aTimer.Interval = 1000
            aTimer.Enabled = True

            getCebula(foundInputFile).InvokeMember("Click")
            aTimer.Enabled = False

            getCebula(foundInputSend).InvokeMember("Click")
            Application.DoEvents()
            Thread.Sleep(500)
            IsFinish = False
            Dim isReloading = True

            Do Until isReloading = False
                Thread.Sleep(100)
                WebBro.InvokeCustom(Sub() isReloading = WebBro.IsBusy)
            Loop

            Do Until IsFinish = True
                Thread.Sleep(100)
                WebBro.InvokeCustom(Sub() IsFinish = (WebBro.ReadyState = WebBrowserReadyState.Complete))
            Loop

            getCebula = Nothing

            Do While IsNothing(getCebula)
                Thread.Sleep(100)
                WebBro.InvokeCustom(Sub() getCebula = WebBro.Document.GetElementsByTagName("input"))
            Loop

            For k = 0 To getCebula.Count - 1

                If getCebula(k).GetAttribute("type") = "text" Then
                    foundInputLink = k
                End If
            Next

            uploadedLink = getCebula(foundInputLink).GetAttribute("value")
            Me.Invoke(DirectCast(Function() LB_Uploaded.Items.Add(uploadedLink), MethodInvoker))

            Me.Invoke(DirectCast(Sub() totalfilesOut = LB_Uploaded.Items.Count, MethodInvoker))

            percentageBar = (totalfilesOut / totalfilesInt) * 100
            Me.Invoke(DirectCast(Sub() ProgBar_Status.Value = percentageBar, MethodInvoker))
            'Thread.Sleep(1000)
        Next
        Me.Invoke(DirectCast(Sub() ProgBar_Status.Value = ProgBar_Status.Maximum, MethodInvoker))
        Me.Invoke(DirectCast(Sub() lbl_Status.Text = "Status: Complete", MethodInvoker))

        _WaitHandle_FirstThreadDone.Set()
    End Sub
    Private Sub btn_SelectFile_Click(sender As Object, e As EventArgs) Handles btn_SelectFile.Click
        OpenFileDialog1.ShowDialog()

        Dim selectedFiles As String() = OpenFileDialog1.FileNames

        If Not IsNothing(selectedFiles) Then
            'Cos wybrane
            For i = LBound(selectedFiles) To UBound(selectedFiles)
                LB_Pending.Items.Add(selectedFiles(i))
            Next
        End If
    End Sub

    Private Sub btn_Clear_Click(sender As Object, e As EventArgs) Handles btn_Clear.Click
        LB_Pending.Items.Clear()
        LB_Uploaded.Items.Clear()
        ProgBar_Status.Value = ProgBar_Status.Minimum
        lbl_Status.Text = "Status: Ready"
    End Sub

    Private Sub btn_Upload_Click(sender As Object, e As EventArgs) Handles btn_Upload.Click
        'Prog_Bar_1.Enabled = True
        'Prog_Bar_1.Update()
        Call StartNavigate()
        'ThreadBrowse.Join()
    End Sub

    Private Sub OnTimedEvent(source As Object, e As Timers.ElapsedEventArgs)
        aTimer.Stop()

        SendKeys.SendWait(PubFilePath) 'Fill in the full file path and name you want to open
        SendKeys.SendWait("{TAB 2}") 'Move focus to the Open button
        SendKeys.SendWait("{ENTER}") 'Press the Open button
        'Return
    End Sub

    Private Sub btn_Copy_Click(sender As Object, e As EventArgs) Handles btn_Copy.Click
        Call CopyLinks()
    End Sub

    Public Sub CopyLinks()
        Dim links As String
        For i = 0 To LB_Uploaded.Items.Count - 1
            links &= LB_Uploaded.Items(i).ToString & vbCrLf
        Next
        links = Trim(links)
        Clipboard.SetText(links)
    End Sub

    Public Function extractFilePath(rawArgs() As String) As String()
        Dim pathpattern As String
        pathpattern = "^(?:[a-zA-Z]\:(\\|\/)|file\:\/\/|\\\\|\.(\/|\\))([^\\\/\:\*\?\<\>\""\|]+(\\|\/){0,1})+$"
        Dim matches As Integer = 0

        Dim filesArr As String()
        ReDim filesArr(0) '1-element array
        For i = 0 To UBound(rawArgs)
            If Regex.IsMatch(rawArgs(i), pathpattern) Then
                matches += 1
                If matches > filesArr.Length Then
                    ReDim Preserve filesArr(matches - 1)
                    filesArr(matches - 1) = rawArgs(i)
                Else
                    filesArr(matches - 1) = rawArgs(i)
                End If
            End If
        Next

        If filesArr(0) = "" Then
            filesArr(0) = "ERROR"
        End If

        Return filesArr
    End Function

    Public Sub AutoModeProcess()
        Call StartNavigate()
        _WaitHandle_FirstThreadDone.WaitOne()
        Call CopyLinks()
        Application.Exit()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '/a - auto mode - gets files, uploads & copies to clipboard & exit
        '/q - quiet mode - nie wiem czy sie uda
        Dim AutoMode As Boolean = False
        'Dim QuietMode As Boolean = False
        Dim execArgs As String()
        Dim apppath As String
        apppath = Application.ExecutablePath
        'MsgBox(apppath)
        execArgs = Environment.GetCommandLineArgs
        Dim filepathArgs As String()
        filepathArgs = extractFilePath(execArgs)

        For j = 0 To execArgs.Length - 1
            If execArgs(j) = "/a" Then
                AutoMode = True
            ElseIf execArgs(j) = "/q" Then
                QuietMode = True
                Me.ShowInTaskbar = False
                'Me.WindowState = 1
            End If
        Next

        For i = 0 To filepathArgs.Length - 1
            If filepathArgs(i).ToString <> "ERROR" Then
                If filepathArgs(i).ToString <> apppath.ToString Then
                    LB_Pending.Items.Add(filepathArgs(i).ToString)
                End If
            End If
        Next

        'Dim text As String
        'For i = 0 To UBound(filepathArgs)
        '    text &= filepathArgs(i).ToString
        'Next

        If AutoMode = True Then
            'MsgBox(filepathArgs.Length.ToString)
            'MsgBox(text)
            If filepathArgs.Length > 1 Then

                ThreadAutoMode = New Thread(AddressOf AutoModeProcess)
                ThreadAutoMode.Name = "AutoModeThread"
                ThreadAutoMode.SetApartmentState(ApartmentState.STA)

                ThreadAutoMode.Start()
            Else
                MsgBox("Cannot find files to upload, add file paths in startup command." & vbCrLf & "Application will close.", vbOKOnly, "Missing file parameter")
                Application.Exit()
            End If
        ElseIf QuietMode = True And AutoMode = False
            MsgBox("Quiet parameter can be used in auto-mode only." & vbCrLf & "Application will close.", vbOKOnly, "Wrong startup parameters")
            Application.Exit()
        End If

    End Sub

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If QuietMode = True Then
            Me.Hide()
        End If
    End Sub
End Class
