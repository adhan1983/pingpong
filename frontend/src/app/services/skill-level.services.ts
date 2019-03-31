import { HttpClient } from '@angular/common/http';
import { Injectable } from "@angular/core";

import { API_URL } from '../api-config';

@Injectable()
export class SkillLevelService {
    constructor(private http: HttpClient){};

    getSkillLevels(){
        return this.http.get(API_URL+'/SkillLevels');
    }
}