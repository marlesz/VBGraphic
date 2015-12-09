Public Class Form2
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            pobierz_kolor(TextBox1.Text, TextBox2.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Public Sub pobierz_kolor(ByVal X As Integer, ByVal Y As Integer)
        Try
            Dim obrazek As Bitmap
            obrazek = Form1.PictureBox1.Image
            Dim kolor As Color
            kolor = obrazek.GetPixel(X, Y) 'zwraca kolor
            Label8.Text = kolor.R
            Label7.Text = kolor.G
            Label6.Text = kolor.B
            Label11.Text = (kolor.GetHue()).ToString("0.000")
            Label10.Text = (kolor.GetSaturation()).ToString("0.000")
            Label9.Text = Math.Max(Math.Max(kolor.R, kolor.G), kolor.B)
            Dim K As Double
            K = 1 - Math.Max(Math.Max(kolor.R / 255, kolor.G / 255), kolor.B / 255)
            Label21.Text = Math.Round(K * 100)

            If K <> 1 Then
                Label17.Text = Math.Round(((1 - kolor.R / 255 - K) / (1 - K)) * 100)
                Label16.Text = Math.Round(((1 - kolor.G / 255 - K) / (1 - K)) * 100)
                Label15.Text = Math.Round(((1 - kolor.B / 255 - K) / (1 - K)) * 100)
            Else
                Label17.Text = 0
                Label16.Text = 0
                Label15.Text = 0
            End If
            'K = 1 - max(R/255, G/255, B/255)
            'C = (1 - R/255 - K) / (1 - K)
            'M = (1 - G/255 - K) / (1 - K)
            'Y = (1 - B/255 - K) / (1 - K)


            PictureBox1.BackColor = kolor
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try

    End Sub

End Class