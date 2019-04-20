Public Class RuntimeException

    Private Sub RuntimeException_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

        Dim t As New Threading.Thread(Sub()

                                          If Me.InvokeRequired Then
                                              Me.Invoke(Sub()
                                                            MessageBox.Show(Me, My.Settings.MsgBoxText, "Runtime Exception", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                                        End Sub)
                                          Else
                                              MessageBox.Show(Me, My.Settings.MsgBoxText, "Runtime Exception", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                          End If

                                          If My.Settings.ShowAdditionalMsgBox And My.Settings.AdditionalMsgBoxText <> String.Empty Then
                                              If Me.InvokeRequired Then
                                                  Me.Invoke(Sub()
                                                                MessageBox.Show(Me, My.Settings.AdditionalMsgBoxText, "Runtime Exception", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                                            End Sub)
                                              Else
                                                  MessageBox.Show(Me, My.Settings.AdditionalMsgBoxText, "Runtime Exception", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                              End If
                                          End If

                                          Environment.Exit(1)

                                      End Sub)

        t.IsBackground = True
        t.Start()

    End Sub

End Class