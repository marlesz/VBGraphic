Public Class Form3
    Dim tab() As Integer
    Dim kolor As Color
    Sub New(ByRef tab() As Integer, ByVal kolor As Color, ByVal tekst As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.tab = tab
        Me.kolor = kolor
        Me.Text = tekst
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

        Dim y1, y2 As Integer
        For x As Integer = 0 To 255
            y1 = Panel1.Height - 1 ' -1, bo zaczynamy od zera
            y2 = (Panel1.Height - 1) - (tab(x) * 256 / tab.Max)
            e.Graphics.DrawLine(New Pen(kolor), x, y1, x, y2)
        Next

    End Sub
End Class