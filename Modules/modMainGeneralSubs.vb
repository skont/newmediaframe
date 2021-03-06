﻿Imports System.Xml


Module modMainGeneralSubs

    Public Function GetSoftVersion()
        Dim ver As String = String.Empty

        Try

            Dim m_xmld = New XmlDocument()

            m_xmld.Load(Application.ExecutablePath & ".manifest")

            ver = m_xmld.ChildNodes.Item(1).ChildNodes.Item(0).Attributes.GetNamedItem("version").Value

        Catch ex As Exception

        End Try

        Return ver

    End Function


    

    Public Sub RegisterDlls()
        Cursor.Current = Cursors.WaitCursor

        Dim dllpath As String = Application.StartupPath & "\dll\"

        Dim spath(2) As String
        spath(0) = dllpath + "crviewer.dll"
        spath(1) = dllpath + "craxddrt.dll"



        'Register the DLLs.
        For i = 0 To 1
            Try

                Process.Start("regsvr32.exe ", """" & spath(i) & """")
            Catch ex As Exception
                WriteLogEntry("The following DLL did not register." & vbLf & spath(i) & vbLf & " Reason:" & vbLf & ex.Message)
            End Try

        Next

    End Sub


    Public Function getColor(ByVal name As String) As Color
        Dim c As Color

        Select Case name.ToLower

            Case "lightgreen"
                c = Color.LightGreen
            Case "lime"
                c = Color.Lime
            Case "green"
                c = Color.Green
            Case "lightblue"
                c = Color.LightBlue
            Case "cyan"
                c = Color.Cyan
            Case "blue"
                c = Color.Blue
            Case "red"
                c = Color.Red
            Case "darkred"
                c = Color.DarkRed
            Case "yellow"
                c = Color.Yellow
            Case "gray"
                c = Color.Gray
            Case "brown"
                c = Color.Brown
            Case "orange"
                c = Color.Orange

        End Select

        Return c
    End Function


End Module
