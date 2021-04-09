﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DevFreela.Core.Entities
{
    class UserSkill : BaseEntity
    {
        public int IdUser { get; private set; }
        public int IdSkill { get; private set; }

        public UserSkill(int idUser, int idSkill)
        {
            IdUser = idUser;
            IdSkill = idSkill;
        }
    }
}
