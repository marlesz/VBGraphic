Public Class Form1
    Public bitmapa2 As Bitmap
    Dim x, y As Integer
    Public histR(255) As Integer   'deklaracja tablicy, w nawiasie największy indeks
    Public histG(255) As Integer
    Public histB(255) As Integer
    Private Sub OtwórzToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OtwórzToolStripMenuItem.Click
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            'MessageBox.Show(OpenFileDialog1.FileName) -wyswietlanie sciezki do pliku w MessageBox'
            Try
                PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName) 'zwraca obiekt klasy system drawing image'
            Catch ex As Exception
                MessageBox.Show("Błędny format pliku!")
            End Try
        End If
    End Sub


    Private Sub PictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove
        x = e.X
        y = e.Y
        Label4.Text = x
        Label3.Text = y
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        If Form2.Visible = True Then
            Form2.TextBox1.Text = x
            Form2.TextBox2.Text = y
            Form2.pobierz_kolor(x, y)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form2.Show()
    End Sub

    Private Sub ZapiszToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZapiszToolStripMenuItem.Click
        SaveFileDialog1.Filter = "Jpeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif|All Files (*.*)|*.*"
        If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If SaveFileDialog1.FileName <> "" Then
                Select Case SaveFileDialog1.FilterIndex
                    Case 1
                        PictureBox1.Image.Save(SaveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg)

                    Case 2
                        PictureBox1.Image.Save(SaveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Bmp)

                    Case 3
                        PictureBox1.Image.Save(SaveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Gif)
                    Case 4
                        PictureBox1.Image.Save(SaveFileDialog1.FileName)
                End Select

            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'obrót w prawo
        Dim obrazek As Bitmap = PictureBox1.Image

        'instrukcje przekształacaące obraz 
        obrazek.RotateFlip(RotateFlipType.Rotate90FlipNone)


        'wyświetlenie wyniku
        PictureBox1.Image = obrazek
        PictureBox1.Refresh()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'obrót w lewo
        Dim obrazek As Bitmap = PictureBox1.Image

        'instrukcje przekształacaące obraz 
        obrazek.RotateFlip(RotateFlipType.Rotate270FlipNone)


        'wyświetlenie wyniku
        PictureBox1.Image = obrazek
        PictureBox1.Refresh()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        'lustrzane pionowe
        Dim obrazek As Bitmap = PictureBox1.Image

        'instrukcje przekształacaące obraz 
        obrazek.RotateFlip(RotateFlipType.RotateNoneFlipX)


        'wyświetlenie wyniku
        PictureBox1.Image = obrazek
        PictureBox1.Refresh()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        'lustrzane poziome
        Dim obrazek As Bitmap = PictureBox1.Image

        'instrukcje przekształacaące obraz 
        obrazek.RotateFlip(RotateFlipType.RotateNoneFlipY)


        'wyświetlenie wyniku
        PictureBox1.Image = obrazek
        PictureBox1.Refresh()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        'negacja
        Dim obrazek As Bitmap = PictureBox1.Image
        Dim kolor As Color
        Dim nR, nG, nB As Integer

        'instrukcje przekształacaące obraz 
        For y As Integer = 0 To obrazek.Height - 1
            For x As Integer = 0 To obrazek.Width - 1
                'pobranie wartości piksela
                kolor = obrazek.GetPixel(x, y)

                'funkcja przekształcenia
                nR = 255 - kolor.R
                nG = 255 - kolor.G
                nB = 255 - kolor.B

                'zapis nowej wartości piksela
                kolor = Color.FromArgb(nR, nG, nB)
                obrazek.SetPixel(x, y, kolor)
            Next
        Next


        'wyświetlenie wyniku
        PictureBox1.Image = obrazek
        PictureBox1.Refresh()

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click 'jasność kontrast
        Form4.ShowDialog()
    End Sub

    Public Sub Jasnosc(ByVal a As Integer, ByVal obrazek As Bitmap)

        Dim kolor As Color
        Dim nR, nG, nB As Integer
        Dim LUT(255) As Integer
        Form5.ProgressBar1.Value = 0
        Form5.ProgressBar1.Maximum = obrazek.Height

        If Form4.CheckBox1.Checked = False Then Form5.Show()

        For i As Integer = 0 To 255
            LUT(i) = i + a
            If LUT(i) < 0 Then LUT(i) = 0
            If LUT(i) > 255 Then LUT(i) = 255
        Next

        'instrukcje przekształacaące obraz 
        For y As Integer = 0 To obrazek.Height - 1
            For x As Integer = 0 To obrazek.Width - 1
                'pobranie wartości piksela
                kolor = obrazek.GetPixel(x, y)

                'funkcja przekształcenia
                nR = LUT(kolor.R)
                nG = LUT(kolor.G)
                nB = LUT(kolor.B)


                'zapis nowej wartości piksela
                kolor = Color.FromArgb(nR, nG, nB)
                obrazek.SetPixel(x, y, kolor)
            Next
            Form5.ProgressBar1.Value += 1
        Next


        'wyświetlenie wyniku
        PictureBox1.Image = obrazek
        PictureBox1.Refresh()
        Form5.Close()
    End Sub


    Public Sub Kontrast(ByVal a As Integer, ByVal obrazek As Bitmap) 'kontrast

        Dim kolor As Color
        Dim nR, nG, nB As Integer
        Dim LUT(255) As Integer
        Form5.ProgressBar1.Value = 0
        Form5.ProgressBar1.Maximum = obrazek.Height


        If Form4.CheckBox1.Checked = False Then Form5.Show()

        For i As Integer = 0 To 255
            LUT(i) = ((i - a) * 255) / (255 - 2 * a)
            If LUT(i) < 0 Then LUT(i) = 0
            If LUT(i) > 255 Then LUT(i) = 255
        Next

        'instrukcje przekształacaące obraz 
        For y As Integer = 0 To obrazek.Height - 1
            For x As Integer = 0 To obrazek.Width - 1
                'pobranie wartości piksela
                kolor = obrazek.GetPixel(x, y)

                'funkcja przekształcenia
                nR = LUT(kolor.R)
                nG = LUT(kolor.G)
                nB = LUT(kolor.B)


                'zapis nowej wartości piksela
                kolor = Color.FromArgb(nR, nG, nB)
                obrazek.SetPixel(x, y, kolor)
            Next
            Form5.ProgressBar1.Value += 1
        Next

        'wyświetlenie wyniku
        PictureBox1.Image = obrazek
        PictureBox1.Refresh()
        Form5.Close()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click 'zmiana  z koloru na greyscale

        Dim obrazek As Bitmap
        obrazek = PictureBox1.Image()
        Dim kolor As Color
        Dim nSz As Integer
        Dim nR, nG, nB As Integer

        Form5.ProgressBar1.Value = 0
        Form5.ProgressBar1.Maximum = obrazek.Height
        Form5.Show()

        'instrukcje przekształacaące obraz 
        For y As Integer = 0 To obrazek.Height - 1
            For x As Integer = 0 To obrazek.Width - 1

                'pobranie wartości piksela
                kolor = obrazek.GetPixel(x, y)
                nR = kolor.R
                nG = kolor.G
                nB = kolor.B

                'funkcja przekształcenia

                nSz = (nR + nG + nB) / 3

                'zapis nowej wartości piksela
                kolor = Color.FromArgb(nSz, nSz, nSz)
                obrazek.SetPixel(x, y, kolor)
            Next
            Form5.ProgressBar1.Value += 1
        Next

        'wyświetlenie wyniku
        PictureBox1.Image = obrazek
        PictureBox1.Refresh()
        Form5.Close()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click 'automatyczny kontrast
        auto_kontrast2(0)
    End Sub
    Public Sub histogram()
        For i As Integer = 0 To 255
            histR(i) = 0
            histG(i) = 0
            histB(i) = 0
        Next

        Dim obrazek As Bitmap
        obrazek = PictureBox1.Image
        Dim kolor As Color
        Dim x, y As Integer

        For x = 0 To obrazek.Width - 1 'Me - oznacza, że chodzi o zmienną globalną z klasy, w której piszemy (Form1), np. Me.x, bez Me, odwołanie do lokalnej zmiennej
            For y = 0 To obrazek.Height - 1
                kolor = obrazek.GetPixel(x, y)
                histR(kolor.R) += 1
                histG(kolor.G) += 1
                histB(kolor.B) += 1
            Next
        Next


    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click 'autokontrast ulepszony
        Form6.Show()
    End Sub

    Public Sub auto_kontrast2(ByVal p As Integer)
        Dim obrazek As Bitmap = PictureBox1.Image
        Dim prg1R, prg2R, prg1G, prg2G, prg1B, prg2B As Integer
        Dim i As Integer
        Dim kolor As Color
        Dim nR, nG, nB As Integer
        Dim LUTR(255) As Integer
        Dim LUTB(255) As Integer
        Dim LUTG(255) As Integer

        Form5.ProgressBar1.Value = 0
        Form5.ProgressBar1.Maximum = obrazek.Height
        Form5.Show()

        histogram()

        i = 0
        While histR(i) <= p
            i += 1
        End While
        prg1R = i
        i = 0
        While histG(i) <= p
            i += 1
        End While
        prg1G = i

        i = 0
        While histB(i) <= p
            i += 1
        End While
        prg1B = i

        i = 255
        While histR(i) <= p
            i -= 1
        End While
        prg2R = i

        i = 255
        While histG(i) <= p
            i -= 1
        End While
        prg2G = i

        i = 255
        While histB(i) <= p
            i -= 1
        End While
        prg2B = i



        For i = 0 To 255
            LUTR(i) = ((i - prg1R) * 255) / (prg2R - prg1R)
            If LUTR(i) < 0 Then LUTR(i) = 0
            If LUTR(i) > 255 Then LUTR(i) = 255

            LUTG(i) = ((i - prg1G) * 255) / (prg2G - prg1G)
            If LUTG(i) < 0 Then LUTG(i) = 0
            If LUTG(i) > 255 Then LUTG(i) = 255

            LUTB(i) = ((i - prg1B) * 255) / (prg2B - prg1B)
            If LUTB(i) < 0 Then LUTB(i) = 0
            If LUTB(i) > 255 Then LUTB(i) = 255
        Next

        'instrukcje przekształacaące obraz 
        For y As Integer = 0 To obrazek.Height - 1
            For x As Integer = 0 To obrazek.Width - 1
                'pobranie wartości piksela
                kolor = obrazek.GetPixel(x, y)

                'funkcja przekształcenia
                nR = LUTR(kolor.R)
                nG = LUTG(kolor.G)
                nB = LUTB(kolor.B)

                'zapis nowej wartości piksela
                kolor = Color.FromArgb(nR, nG, nB)
                obrazek.SetPixel(x, y, kolor)
            Next
            Form5.ProgressBar1.Value += 1
        Next

        'wyświetlenie wyniku
        PictureBox1.Image = obrazek
        PictureBox1.Refresh()
        Form5.Close()

    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click 'użyteczny zakres histogramu

        Dim obrazek As Bitmap
        obrazek = PictureBox1.Image
        Dim kolor As Color
        Dim licz As Integer = 0
        Dim sumaR As Integer = 0
        Dim sumaG As Integer = 0
        Dim sumaB As Integer = 0
        Dim prg1R, prg2R, prg1G, prg2G, prg1B, prg2B As Integer
        Dim nR, nG, nB As Integer
        Dim LUTR(255) As Integer
        Dim LUTB(255) As Integer
        Dim LUTG(255) As Integer

        Form5.ProgressBar1.Value = 0
        Form5.ProgressBar1.Maximum = obrazek.Height
        Form5.Show()

        For x = 0 To obrazek.Width - 1 '
            For y = 0 To obrazek.Height - 1
                kolor = obrazek.GetPixel(x, y)
                sumaR = sumaR + kolor.R
                sumaG = sumaG + kolor.G
                sumaB = sumaB + kolor.B
                licz = licz + 1
            Next
        Next
        Dim sredniaR As Integer = sumaR / licz
        Dim sredniaG As Integer = sumaG / licz
        Dim sredniaB As Integer = sumaB / licz
        Dim kwadratroznicyR As Integer = 0
        Dim kwadratroznicyG As Integer = 0
        Dim kwadratroznicyB As Integer = 0



        For x = 0 To obrazek.Width - 1
            For y = 0 To obrazek.Height - 1
                kolor = obrazek.GetPixel(x, y)
                kwadratroznicyR = kwadratroznicyR + (kolor.R - sredniaR) ^ 2
                kwadratroznicyG = kwadratroznicyG + (kolor.G - sredniaG) ^ 2
                kwadratroznicyB = kwadratroznicyB + (kolor.B - sredniaB) ^ 2
            Next
        Next
        Dim dystR As Double = Math.Sqrt(kwadratroznicyR / licz)
        Dim dystG As Double = Math.Sqrt(kwadratroznicyG / licz)
        Dim dystB As Double = Math.Sqrt(kwadratroznicyB / licz)
        prg1R = Math.Round(sredniaR - 2 * dystR, 2)
        prg1G = Math.Round(sredniaG - 2 * dystG, 2)
        prg1B = Math.Round(sredniaB - 2 * dystB, 2)
        prg2R = Math.Round(sredniaR + 2 * dystR, 2)
        prg2G = Math.Round(sredniaG + 2 * dystG, 2)
        prg2B = Math.Round(sredniaB + 2 * dystB, 2)


        For i = 0 To 255
            LUTR(i) = ((i - prg1R) * 255) / (prg2R - prg1R)
            If LUTR(i) < 0 Then LUTR(i) = 0
            If LUTR(i) > 255 Then LUTR(i) = 255

            LUTG(i) = ((i - prg1G) * 255) / (prg2G - prg1G)
            If LUTG(i) < 0 Then LUTG(i) = 0
            If LUTG(i) > 255 Then LUTG(i) = 255

            LUTB(i) = ((i - prg1B) * 255) / (prg2B - prg1B)
            If LUTB(i) < 0 Then LUTB(i) = 0
            If LUTB(i) > 255 Then LUTB(i) = 255
        Next

        'instrukcje przekształacaące obraz 
        For y As Integer = 0 To obrazek.Height - 1
            For x As Integer = 0 To obrazek.Width - 1
                'pobranie wartości piksela
                kolor = obrazek.GetPixel(x, y)

                'funkcja przekształcenia
                nR = LUTR(kolor.R)
                nG = LUTG(kolor.G)
                nB = LUTB(kolor.B)

                'zapis nowej wartości piksela
                kolor = Color.FromArgb(nR, nG, nB)
                obrazek.SetPixel(x, y, kolor)
            Next
            Form5.ProgressBar1.Value += 1
        Next

        'wyświetlenie wyniku
        PictureBox1.Image = obrazek
        PictureBox1.Refresh()
        Form5.Close()

    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click 'wyrównanie histogramu
        Dim obrazek As Bitmap
        obrazek = PictureBox1.Image
        Dim kolor As Color
        Dim LUTR(255) As Integer
        Dim LUTB(255) As Integer
        Dim LUTG(255) As Integer
        Dim nR, nG, nB As Integer

        Form5.ProgressBar1.Value = 0
        Form5.ProgressBar1.Maximum = obrazek.Height
        Form5.Show()

        histogram()

        Dim licz As Integer = obrazek.Width * obrazek.Height

        Dim dystR(255) As Integer
        Dim dystG(255) As Integer
        Dim dystB(255) As Integer

        dystR(0) = histR(0)
        dystG(0) = histG(0)
        dystB(0) = histB(0)
        LUTR(0) = (255 * dystR(0)) / licz
        LUTG(0) = (255 * dystG(0)) / licz
        LUTB(0) = (255 * dystB(0)) / licz

        For i As Integer = 1 To 255
            dystR(i) = histR(i) + dystR(i - 1)
            dystG(i) = histG(i) + dystG(i - 1)
            dystB(i) = histB(i) + dystB(i - 1)

            LUTR(i) = (255 * dystR(i)) / licz

            LUTG(i) = (255 * dystG(i)) / licz

            LUTB(i) = (255 * dystB(i)) / licz



        Next


        'instrukcje przekształacaące obraz 
        For y As Integer = 0 To obrazek.Height - 1
            For x As Integer = 0 To obrazek.Width - 1
                'pobranie wartości piksela
                kolor = obrazek.GetPixel(x, y)
                'funkcja przekształcenia
                nR = LUTR(kolor.R)
                nG = LUTG(kolor.G)
                nB = LUTB(kolor.B)

                'zapis nowej wartości piksela
                kolor = Color.FromArgb(nR, nG, nB)
                obrazek.SetPixel(x, y, kolor)
            Next
            Form5.ProgressBar1.Value += 1
        Next

        'wyświetlenie wyniku
        PictureBox1.Image = obrazek
        PictureBox1.Refresh()
        Form5.Close()
    End Sub

    Private Sub KompozycjaRGBToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KompozycjaRGBToolStripMenuItem.Click
        Form7.ShowDialog()
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Form8.ShowDialog()
    End Sub

    Public Sub Erozja(ByVal matrixSize As Integer, ByVal obrazek As Bitmap) 'Erozja (filtr minimalny)
        Dim bitmapa3 As Bitmap
        bitmapa3 = obrazek.Clone 'stworzenie kopii obrazu
        Dim kolor As Color
        Dim nR, nG, nB As Integer
        Dim filterOffset As Integer = Int((matrixSize) / 2)

        Form5.ProgressBar1.Value = 0
        Form5.ProgressBar1.Maximum = obrazek.Height
        If Form8.CheckBox1.Checked = False Then Form5.Show()

        'instrukcje przekształcające obraz
        If matrixSize Mod 2 <> 0 Then
            For offsetY As Integer = filterOffset To obrazek.Height - 1 - filterOffset
                For offsetX As Integer = filterOffset To obrazek.Width - 1 - filterOffset
                    nR = bitmapa3.GetPixel(offsetX, offsetY).R
                    nG = bitmapa3.GetPixel(offsetX, offsetY).G
                    nB = bitmapa3.GetPixel(offsetX, offsetY).B
                    For filterY As Integer = -filterOffset To filterOffset
                        For filterX As Integer = -filterOffset To filterOffset
                            kolor = bitmapa3.GetPixel(offsetX + filterX, offsetY + filterY)
                            If kolor.R < nR Then nR = kolor.R
                            If kolor.G < nG Then nG = kolor.G
                            If kolor.B < nB Then nB = kolor.B
                        Next
                    Next
                    kolor = Color.FromArgb(nR, nG, nB)
                    obrazek.SetPixel(offsetX, offsetY, kolor)
                Next
                Form5.ProgressBar1.Value += 1
            Next

            Using gr As Graphics = Graphics.FromImage(obrazek)
                Dim src_rect As New Rectangle(filterOffset, filterOffset, obrazek.Width - 2 * filterOffset, obrazek.Height - 2 * filterOffset)
                Dim dst_rect As New Rectangle(0, 0, obrazek.Width, obrazek.Height)
                gr.DrawImage(obrazek, dst_rect, src_rect, GraphicsUnit.Pixel)
            End Using

        Else
            For offsetY As Integer = filterOffset To obrazek.Height - 1 - (filterOffset - 1)
                For offsetX As Integer = filterOffset To obrazek.Width - 1 - (filterOffset - 1)
                    nR = bitmapa3.GetPixel(offsetX, offsetY).R
                    nG = bitmapa3.GetPixel(offsetX, offsetY).G
                    nB = bitmapa3.GetPixel(offsetX, offsetY).B
                    For filterY As Integer = -filterOffset To filterOffset - 1
                        For filterX As Integer = -filterOffset To filterOffset - 1
                            kolor = bitmapa3.GetPixel(offsetX + filterX, offsetY + filterY)
                            If kolor.R < nR Then nR = kolor.R
                            If kolor.G < nG Then nG = kolor.G
                            If kolor.B < nB Then nB = kolor.B
                        Next
                    Next
                    kolor = Color.FromArgb(nR, nG, nB)
                    obrazek.SetPixel(offsetX, offsetY, kolor)
                Next
                Form5.ProgressBar1.Value += 1
            Next

            Using gr As Graphics = Graphics.FromImage(obrazek)
                Dim src_rect As New Rectangle(filterOffset, filterOffset, obrazek.Width - ((2 * filterOffset) - 1), obrazek.Height - ((2 * filterOffset) - 1))
                Dim dst_rect As New Rectangle(0, 0, obrazek.Width, obrazek.Height)
                gr.DrawImage(obrazek, dst_rect, src_rect, GraphicsUnit.Pixel)
            End Using
        End If

        PictureBox1.Image = obrazek
        PictureBox1.Refresh()
        Form5.Close()
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            histogram()
            Dim oknoR As Form3 = New Form3(histR, Color.Red, "R")
            Dim oknoG As Form3 = New Form3(histG, Color.Green, "G")
            Dim oknoB As Form3 = New Form3(histB, Color.Blue, "B")

            oknoR.Show()
            oknoG.Show()
            oknoB.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
    End Sub

End Class
