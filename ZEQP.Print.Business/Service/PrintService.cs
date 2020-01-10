﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZEQP.Print.Models;
using ZEQP.Print.Framework;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace ZEQP.Print.Business
{
    public class PrintService : IPrintService
    {
        private IPrintModelService PrintSvc { get; set; }
        private IMergeDocService MergeSvc { get; set; }
        public IHostEnvironment HostEnv { get; set; }
        public PrintService(IMergeDocService mergeSvc,IHostEnvironment hostEnv)
        {
            this.MergeSvc = mergeSvc;
            this.HostEnv = hostEnv;
        }
        public ComResult Print(PrintModel model)
        {
            var xpsStream = this.MergeSvc.Merge(model);
            if (model.Action == PrintActionType.File || model.Action == PrintActionType.PrintAndFile)
            {
                var dirPath = $"{this.HostEnv.ContentRootPath}\\wwwroot\\download\\{DateTime.Now.ToString("yyyyMMdd")}";
                if (!System.IO.Directory.Exists(dirPath)) System.IO.Directory.CreateDirectory(dirPath);
                var fileName = $"{DateTime.Now.ToString("yyyyMMddHHmmssfff")}_{model.Template}";
                var filePath = $"{dirPath}\\{fileName}";
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    xpsStream.WriteTo(fileStream);
                    fileStream.Close();
                }
                if (model.Action == PrintActionType.PrintAndFile)
                { 

                }
                return new ComResult() { Code = "0", Msg = "操作成功", Data = filePath.Replace($"{this.HostEnv.ContentRootPath}\\wwwroot", ""), Success = true };
            }

            XpsPrintHelper.Print(xpsStream, model.PrintName, Guid.NewGuid().ToString("N"), model.IsWait);

            return new ComResult();
        }
    }
}
