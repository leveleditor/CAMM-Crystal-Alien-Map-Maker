Namespace My

    ' The following events are available for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication
        '#If Debug = False Then
        '        Private Sub MyApplication_UnhandledException(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException
        '            MsgBox("An unhandled exception ocurred, please report this if you can:" + vbNewLine + e.Exception.Message + vbNewLine + vbNewLine + e.Exception.StackTrace, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        '        End Sub
        '#End If
    End Class

End Namespace

