Imports System.Collections.Generic

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbOperation.Items.Clear()
        cmbOperation.Items.AddRange({
            "Addition",        ' Index 0
            "Subtraction",     ' Index 1
            "Multiplication", ' Index 2
            "Division",       ' Index 3
            "Negation",       ' Index 4
            "Square",         ' Index 5
            "Cube",           ' Index 6
            "OR",            ' Index 7
            "AND",           ' Index 8
            "XOR",           ' Index 9
            "NOT",           ' Index 10
            "Modulus"        ' Index 11
        })
        cmbOperation.SelectedIndex = 0
    End Sub

    Private Sub cmbOperation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOperation.SelectedIndexChanged
        Dim singleNumberOperations As New List(Of Integer) From {4, 5, 6, 10}

        Dim showSecondNum = Not singleNumberOperations.Contains(cmbOperation.SelectedIndex)
        txtNum2.Visible = showSecondNum
        lblNum2.Visible = showSecondNum
    End Sub

    Private Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click
        If Not Integer.TryParse(txtNum1.Text, Nothing) Then
            MessageBox.Show("Please enter a valid first number")
            Return
        End If

        Dim num1 As Integer = Integer.Parse(txtNum1.Text)
        Dim num2 As Integer = 0
        Dim result As Integer = 0

        If cmbOperation.SelectedIndex <> 4 AndAlso ' Negation
           cmbOperation.SelectedIndex <> 5 AndAlso ' Square
           cmbOperation.SelectedIndex <> 6 AndAlso ' Cube
           cmbOperation.SelectedIndex <> 10 Then  ' NOT
            If Not Integer.TryParse(txtNum2.Text, Nothing) Then
                MessageBox.Show("Please enter a valid second number")
                Return
            End If
            num2 = Integer.Parse(txtNum2.Text)
        End If

        Select Case cmbOperation.SelectedIndex
            Case 0 : result = num1 + num2      ' Addition
            Case 1 : result = num1 - num2      ' Subtraction
            Case 2 : result = num1 * num2      ' Multiplication
            Case 3                            ' Division
                If num2 = 0 Then
                    MessageBox.Show("Cannot divide by zero")
                    Return
                End If
                result = num1 \ num2
            Case 4 : result = -num1            ' Negation
            Case 5 : result = num1 * num1      ' Square
            Case 6 : result = num1 * num1 * num1 ' Cube
            Case 7 : result = num1 Or num2     ' OR
            Case 8 : result = num1 And num2    ' AND
            Case 9 : result = num1 Xor num2    ' XOR
            Case 10 : result = Not num1        ' NOT
            Case 11                           ' Modulus
                If num2 = 0 Then
                    MessageBox.Show("Cannot divide by zero")
                    Return
                End If
                result = num1 Mod num2
        End Select

        ' Result
        lblResult.Text = $"Result: {result}"
        lblResult.Visible = True
        lblResult.BringToFront()
        lblResult.Refresh()
    End Sub

    Private Sub lblNum1_Click(sender As Object, e As EventArgs) Handles lblNum1.Click

    End Sub

    Private Sub lblNum2_Click(sender As Object, e As EventArgs) Handles lblNum2.Click

    End Sub

    Private Sub txtNum2_TextChanged(sender As Object, e As EventArgs) Handles txtNum2.TextChanged

    End Sub
End Class