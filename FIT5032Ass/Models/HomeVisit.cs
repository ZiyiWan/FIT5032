//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace FIT5032Ass.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class HomeVisit
    {
        public int Id { get; set; }
        public string Time { get; set; }
        public int TeacherId { get; set; }
    
        public virtual Teacher Teacher { get; set; }
        public virtual Student Student { get; set; }
    }
}
