﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On



<Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
 Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.6.0.0")>  _
Partial Friend NotInheritable Class Settings2
    Inherits Global.System.Configuration.ApplicationSettingsBase
    
    Private Shared defaultInstance As Settings2 = CType(Global.System.Configuration.ApplicationSettingsBase.Synchronized(New Settings2()),Settings2)
    
    Public Shared ReadOnly Property [Default]() As Settings2
        Get
            Return defaultInstance
        End Get
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("")>  _
    Public Property ConComPortName() As String
        Get
            Return CType(Me("ConComPortName"),String)
        End Get
        Set
            Me("ConComPortName") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("")>  _
    Public Property Powerleft() As String
        Get
            Return CType(Me("Powerleft"),String)
        End Get
        Set
            Me("Powerleft") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("1200")>  _
    Public Property ActTime() As String
        Get
            Return CType(Me("ActTime"),String)
        End Get
        Set
            Me("ActTime") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("1200000")>  _
    Public Property ActTimeElapsed() As String
        Get
            Return CType(Me("ActTimeElapsed"),String)
        End Get
        Set
            Me("ActTimeElapsed") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("")>  _
    Public Property LastAction() As String
        Get
            Return CType(Me("LastAction"),String)
        End Get
        Set
            Me("LastAction") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
    Public Property hibernate() As Boolean
        Get
            Return CType(Me("hibernate"),Boolean)
        End Get
        Set
            Me("hibernate") = value
        End Set
    End Property
End Class
