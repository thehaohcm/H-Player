Public Class Form1
    Public PlayAgain As Boolean

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        _play()

    End Sub
    Public Sub _stop()
        player.Ctlcontrols.stop()
        dura.Stop()
        Duration.Text = "00:00 | " + player.currentMedia.durationString
        PlayBar.Value = 0
        Button1.Enabled = True
        Button5.Enabled = False
        Button4.Enabled = False

    End Sub
    Public Sub _play()
        If (player.URL <> "") Then
            PlayBar.Enabled = True
            Me.Text = player.currentMedia.name.ToString + " | H-Player"
            Duration.Text = player.currentMedia.duration
            dura.Start()
            Duration.Text = dura.Interval
            player.Ctlcontrols.play()
            Button1.Enabled = False
            Button4.Enabled = True
            Button5.Enabled = True
            TextBox1.Text = player.currentMedia.sourceURL.ToUpper
        End If


    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Application.CommandLineArgs.Count > 0 Then
            player.URL = My.Application.CommandLineArgs(0)
            _play()
            TextBox1.Text = My.Application.CommandLineArgs(0).ToUpper
        Else

            Button1.Enabled = False
            Button4.Enabled = False
            Button5.Enabled = False
            Duration.Text = "00:00 | 00:00"
            PlayBar.Enabled = False
        End If
        player.settings.volume = 50
        player.uiMode = "none"
        volume.Value = player.settings.volume / 10
        ToolTip1.ToolTipTitle = player.settings.volume.ToString + "%"
        hourse.Start()
        OpenFile.Filter = "Media Player Files|*.asf;*.wma;*.wmv;*.wm;*.asx;*.wax;*.wvx;*.wmx;*.wpl;*.dvr-ms;*.wnd;*.avi;*.mpg;*.mpeg;*m1v;*.mp2;*.mp3;*.mpa;*.mpe;*.m3u;*.mid;*.midi;*.rmi;*.aif;*.aifc;*.aiff;*.au;*.snd;*.wav;*.cda;*.ivf;*.wmz;*.wms;*.mov;*.m4a;*.mp4;*.m4v;*.mp4v;*.3g2;*.3gp2;*.3gp;*.3gpp;*.aac;*.adt;*.adts;*.m2ts|FLV Files|*.flv|All Files (*.*)|*.*"
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PlayBar_MouseCaptureChanged(sender As Object, e As EventArgs) Handles PlayBar.MouseCaptureChanged
        
    End Sub

    Private Sub PlayBar_MouseDown(sender As Object, e As MouseEventArgs) Handles PlayBar.MouseDown
        
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles PlayBar.Scroll
        Try
            If (player.currentMedia.duration <> 0) Then
                Dim NewPerc As Double = Convert.ToDouble(PlayBar.Value) / 100
                Dim DurationVar As Integer = Convert.ToInt32(player.currentMedia.duration * 1000) ' milliseconds
                Dim NewPos As Integer = (DurationVar * NewPerc) / 1000

                player.Ctlcontrols.currentPosition = NewPos
            Else
                PlayBar.Value = 0
            End If
        Catch ex As Exception
            MessageBox.Show("Đã có lỗi xảy ra", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub player_Enter(sender As Object, e As EventArgs) Handles player.Enter

    End Sub


    Private Sub Timer3_Tick(sender As Object, e As EventArgs)

    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        OpenFile.ShowDialog()
    End Sub

    Private Sub OpenFile_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFile.FileOk
        player.URL = OpenFile.FileName.ToString

        _play()
    End Sub

    Private Sub GiớiThiệuVềHPlayerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GiớiThiệuVềHPlayerToolStripMenuItem.Click
        About.Show()
    End Sub

    Private Sub dura_Tick(sender As Object, e As EventArgs) Handles dura.Tick
        ' Update the trackbar.
        Dim CurPos As Integer = Convert.ToInt32(player.Ctlcontrols.currentPosition * 1000) ' milliseconds
        Dim DurationVar As Integer = Convert.ToInt32(player.currentMedia.duration * 1000) ' milliseconds
        If DurationVar > 0 Then
            PlayBar.Value = Convert.ToInt32((CurPos * 100) / DurationVar) ' % complete
        End If
        If (PlayBar.Value = PlayBar.Maximum) Then
            _stop()
        End If
        ' Update the time label
        Duration.Text = player.Ctlcontrols.currentPositionString + " | " + player.currentMedia.durationString
        If player.playState = WMPLib.WMPPlayState.wmppsStopped Then
            Duration.Text = "00:00 | 00:00"
            dura.Enabled = False
            PlayBar.Value = 0
        End If
        If PlayAgain = False Then
        Else
            If player.playState = WMPLib.WMPPlayState.wmppsStopped Then
                _play()
            Else
            End If
        End If

    End Sub

    Private Sub volume_Scroll(sender As Object, e As EventArgs) Handles volume.Scroll
        Dim vol As Integer
        vol = volume.Value * 10
        player.settings.volume = volume.Value * 10
        ToolTip1.ToolTipTitle = Convert.ToString(vol) + "%"

    End Sub

    Private Sub hourse_Tick(sender As Object, e As EventArgs) Handles hourse.Tick
        Dim a = My.Computer.Clock.LocalTime

        texthourse.Text = Format(Now, "hh:mm:ss tt")
        'a.Hour.ToString + ":" + a.Minute.ToString + ":" + a.Second.ToString
    End Sub

    Private Sub Duration_TextChanged(sender As Object, e As EventArgs) Handles Duration.TextChanged

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        _stop()
        
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        player.Ctlcontrols.pause()
        Button4.Enabled = False
        Button1.Enabled = True

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        If player.settings.mute Then
            player.settings.mute = False
            Button2.Image = H_Player.My.Resources.Resources.mute
        Else
            player.settings.mute = True
            Button2.Image = H_Player.My.Resources.Resources.mute_f
        End If

    End Sub

    Private Sub texthourse_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub PlayBar_ValueChanged(sender As Object, e As EventArgs) Handles PlayBar.ValueChanged
        
    End Sub

   
    Private Sub Button3_Click_1(sender As Object, e As EventArgs)
        Form2.Show()
    End Sub
End Class
