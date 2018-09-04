﻿/*************************************************
** auth： zsh2401@163.com
** date:  2018/8/29 4:29:37 (UTC +8:00)
** desc： ...
*************************************************/
using AutumnBox.Basic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutumnBox.Basic.Device.Management.OS
{
    public interface IFileSystem
    {
        void Move(string src, string target, bool isDir = false);
        void Copy(string src, string target, bool isDir = false);
        void Delete(string file);
        void Mkdir(string file);
        string Cat(string file);
        Output Find(string name);
    }
}