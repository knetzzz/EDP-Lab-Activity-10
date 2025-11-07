Imports System.IO
Imports System.Linq

Public Class Form1
    Dim filePath As String = "numbers.txt"

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim num As String = txtNumber.Text.Trim()

            If Not IsNumeric(num) Then
                MessageBox.Show("Please enter a valid number!")
                Exit Sub
            End If

            Using writer As New StreamWriter(filePath, True)
                writer.WriteLine(num)
            End Using

            MessageBox.Show("Number saved successfully!")
            txtNumber.Clear()
        Catch ex As Exception
            MessageBox.Show("Error saving number: " & ex.Message)
        End Try
    End Sub

    Private Sub btnShowSorted_Click(sender As Object, e As EventArgs) Handles btnShowSorted.Click
        Try
            If Not File.Exists(filePath) Then
                MessageBox.Show("No numbers found. Please save some numbers first.")
                Exit Sub
            End If

            Dim lines() As String = File.ReadAllLines(filePath)
            Dim numbers As List(Of Integer) = lines.Where(Function(x) IsNumeric(x)).Select(Function(x) CInt(x)).ToList()

            If numbers.Count = 0 Then
                MessageBox.Show("No valid numbers found in the file.")
                Exit Sub
            End If

            Dim sortedNumbers = numbers.OrderBy(Function(n) n)
            lstNumbers.Items.Clear()
            For Each n In sortedNumbers
                lstNumbers.Items.Add(n)
            Next

        Catch ex As Exception
            MessageBox.Show("Error reading or sorting numbers: " & ex.Message)
        End Try
    End Sub
End Class

