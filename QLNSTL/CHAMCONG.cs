//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLNSTL
{
    using System;
    using System.Collections.Generic;
    
    public partial class CHAMCONG
    {
        public string MANV { get; set; }
        public System.DateTime NGAYLAMVIEC { get; set; }
        public string MATT { get; set; }
        public string GHICHU { get; set; }
    
        public virtual NHANVIEN NHANVIEN { get; set; }
        public virtual TINHTRANG TINHTRANG { get; set; }
    }
}
