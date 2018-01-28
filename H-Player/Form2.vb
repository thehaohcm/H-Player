Public Class Form2

    Private Sub TrackBar1_MouseDown(sender As Object, e As MouseEventArgs) Handles playbar.MouseDown
        Dim dblValue As Double

        ' Jump to the clicked location
        dblValue = (e.X / playbar.Width) * playbar.Maximum

        playbar.Value = Convert.ToInt32(dblValue)
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles playbar.Scroll

    End Sub
End Class