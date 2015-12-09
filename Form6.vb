Public Class Form6

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form1.auto_kontrast2(TrackBar1.Value)
    End Sub


    Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.Scroll
        Label1.Text = TrackBar1.Value
    End Sub

    Private Sub Form6_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Form1.PictureBox1.Image Is Nothing Then 'sprawdzamy czy obiekt jest jakimś elementem 
            TrackBar1.Maximum = CInt(0.02 * Form1.PictureBox1.Image.Width * Form1.PictureBox1.Image.Height)
        End If
    End Sub
End Class