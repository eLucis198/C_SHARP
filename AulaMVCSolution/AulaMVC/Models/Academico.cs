//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AulaMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Academico
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Academico()
        {
            this.NOTA = new HashSet<NOTA>();
        }
    
        public int Id_Academico { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public Nullable<bool> Excluido { get; set; }
        public Nullable<bool> Ativo { get; set; }
        public Nullable<int> MateriaFavorita { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NOTA> NOTA { get; set; }
        public virtual Materia Materia { get; set; }
    }
}