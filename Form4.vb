Public Class Form4
    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        Label3.Text = TrackBar1.Value

        If CheckBox1.Checked = True Then
            Form1.Jasnosc(TrackBar1.Value, Form1.bitmapa2.Clone)
        End If

    End Sub

    Private Sub TrackBar2_Scroll(sender As Object, e As EventArgs) Handles TrackBar2.Scroll
        Label4.Text = TrackBar2.Value

        If CheckBox1.Checked = True Then
            Form1.Kontrast(TrackBar2.Value, Form1.bitmapa2.Clone)
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If CheckBox1.Checked = False Then
            Form1.Jasnosc(TrackBar1.Value, Form1.PictureBox1.Image)
            Form1.Kontrast(TrackBar2.Value, Form1.PictureBox1.Image)
        End If
        Me.Close()
    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Form1.bitmapa2 = Form1.PictureBox1.Image.Clone 'stworzenie kopii obrazu
    End Sub
End Class