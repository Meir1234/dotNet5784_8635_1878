using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL;
internal class EngineersLevel : IEnumerable
{
    static readonly IEnumerable<BO.Level> s_enums =
        (Enum.GetValues(typeof(BO.Level)) as IEnumerable<BO.Level>)!;
    public IEnumerator GetEnumerator() => s_enums.GetEnumerator();
}

internal class StatusList : IEnumerable
{
    static readonly IEnumerable<BO.Status> s_enums =
(Enum.GetValues(typeof(BO.Status)) as IEnumerable<BO.Status>)!;
    public IEnumerator GetEnumerator() => s_enums.GetEnumerator();
}

