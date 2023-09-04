import {Pipe, PipeTransform} from '@angular/core'
@Pipe({
    name:'shortdescription'
})
export class ShortDescriptionPipe implements PipeTransform{
    transform(txt: string, truncIn: number): string {
        if(txt.length > truncIn){
            return txt.substring(0,truncIn)+'...'
        }else{
            return txt
        }
    }
}