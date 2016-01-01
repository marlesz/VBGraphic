Public Class Form7
    Dim kanalR, kanalB, kanalG, obrazek As Bitmap


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            'MessageBox.Show(OpenFileDialog1.FileName)
            Try
                kanalR = Image.FromFile(OpenFileDialog1.FileName)
                Label1.Text = OpenFileDialog1.FileName
            Catch ex As Exception
                MessageBox.Show("Błędny format pliku!")
            End Try

        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            'MessageBox.Show(OpenFileDialog1.FileName)
            Try
                kanalG = Image.FromFile(OpenFileDialog1.FileName)
                Label2.Text = OpenFileDialog1.FileName
            Catch ex As Exception
                MessageBox.Show("Błędny format pliku!")
            End Try

        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            'MessageBox.Show(OpenFileDialog1.FileName)
            Try
                kanalB = Image.FromFile(OpenFileDialog1.FileName)
                Label3.Text = OpenFileDialog1.FileName
            Catch ex As Exception
                MessageBox.Show("Błędny format pliku!")
            End Try

        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If kanalR.Size = kanalG.Size And kanalR.Size = kanalB.Size Then
            Dim obrazek As Bitmap = New Bitmap(kanalR.Width, kanalR.Width)
            Form5.ProgressBar1.Value = 0
            Form5.ProgressBar1.Maximum = obrazek.Height
            If Form4.CheckBox1.Checked = False Then
                Form5.Show()
            End If

            Dim kolorR, kolorG, kolorB As Color
            Dim RR, RG, RB, GR, GG, GB, BR, BG, BB, R, G, B As Integer

            For y As Integer = 0 To obrazek.Height - 1
                For x As Integer = 0 To obrazek.Width - 1
                    'pobrane wartości piksela'
                    kolorR = kanalR.GetPixel(x, y)
                    kolorG = kanalG.GetPixel(x, y)
                    kolorB = kanalB.GetPixel(x, y)
                    RR = kolorR.R
                    RG = kolorR.G
                    RB = kolorR.B

                    GR = kolorG.R
                    GG = kolorG.G
                    GB = kolorG.B

                    BR = kolorB.R
                    BG = kolorB.G
                    BB = kolorB.B


                    R = (RR + RG + RB) / 3
                    G = (GR + GG + GB) / 3
                    B = (BR + BG + BB) / 3


                    'zapis nowej wartości piksela


                    obrazek.SetPixel(x, y, Color.FromArgb(R, G, B))


                Next
                Form5.ProgressBar1.Value += 1
            Next
            Form1.PictureBox1.Image = obrazek
            Form1.PictureBox1.Refresh()
            Form5.Close()
        End If

    End Sub
End Class