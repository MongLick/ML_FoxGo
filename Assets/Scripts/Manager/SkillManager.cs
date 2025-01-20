using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : Singleton<SkillManager>
{
	public List<Skill> skills;

	public void UseSkill(int skillIndex, GameObject user)
	{
		Skill skill = skills[skillIndex];
		skill.Activate(user);
	}
}
