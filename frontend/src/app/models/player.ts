import { SkillLevel } from './skilllevel';

export class Player {
  Id: number;
  FirstName: string;
  LastName: string;
  SkillLevel: SkillLevel;
  SkillLevelId: number;
  Age: number;
  Email: string;

  constructor(firstName: string, lastName: string, skillLevelId: number, age: number, email: string, id?: number){
    if(id)
      this.Id=id;
    
    this.FirstName = firstName;
    this.LastName = lastName;
    this.Age = age;
    this.SkillLevelId = skillLevelId;
    this.Email = email;
  }
}
