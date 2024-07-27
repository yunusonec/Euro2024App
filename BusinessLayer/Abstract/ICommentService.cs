using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICommentService: IGenericService<Comment>
    {
        IEnumerable<Comment> GetCommentsByMatchId(int matchId);
        void AddComment(Comment comment);
    }
}
