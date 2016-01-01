Public Class Form8
    Dim Butt1 As Boolean
    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        NumericUpDown1.Value = TrackBar1.Value
    End Sub

    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Form1.bitmapa2 = Form1.PictureBox1.Image.Clone 'stworzenie kopii obrazu
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Butt1 = True
        If CheckBox1.Checked = False Then
            Form1.Erozja(NumericUpDown1.Value, Form1.PictureBox1.Image)

        End If
        Me.Close()
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        If NumericUpDown1.Value <= 10 Then
            TrackBar1.Value = NumericUpDown1.Value
            TrackBar1.Refresh()
        Else
            TrackBar1.Value = 10
        End If
        If CheckBox1.Checked = True Then
            Form1.Erozja(NumericUpDown1.Value, Form1.bitmapa2.Clone)
        End If

    End Sub

    Private Sub Form8_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Butt1 = False Then
            Form1.PictureBox1.Image = Form1.bitmapa2
        End If
    End Sub

End Class