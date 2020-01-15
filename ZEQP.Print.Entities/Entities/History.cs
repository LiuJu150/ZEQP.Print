﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ZEQP.Print.Entities
{
    public class PrintTask
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// 打印机名称
        /// </summary>
        [MaxLength(100)]
        public string PrintName { get; set; }

        /// <summary>
        /// 打印份数
        /// </summary>
        public int Copies { get; set; }

        /// <summary>
        /// 使用模板
        /// </summary>
        public int TemplateId { get; set; }

        [ForeignKey(nameof(TemplateId))]
        public Template Template { get; set; }


        /// <summary>
        /// 打印方式
        /// </summary>
        public PrintAction Action { get; set; }

        /// <summary>
        /// 是否等待
        /// </summary>
        public bool IsWait { get; set; }

        /// <summary>
        /// http请求URL数据
        /// </summary>
        public string Query { get; set; }
        
        /// <summary>
        /// http请求正文数据
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// 打印次数
        /// </summary>
        public int PrintCount { get; set; }

        /// <summary>
        /// 任务状态
        /// </summary>
        public TaskStatus Status { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime ModifyTime { get; set; }
    }
    /// <summary>
    /// 任务状态
    /// </summary>
    public enum TaskStatus
    { 
        Active,
        Printing,
        Printed
    }
    /// <summary>
    /// 打印方式
    /// </summary>
    public enum PrintAction
    {
        /// <summary>
        /// 打印
        /// </summary>
        Print = 0,
        /// <summary>
        /// 输出成文件
        /// </summary>
        File = 1,
        /// <summary>
        /// 打印并输出成文件
        /// </summary>
        PrintAndFile = 2
    }
}
