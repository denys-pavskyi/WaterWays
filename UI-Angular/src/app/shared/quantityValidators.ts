import { FormControl } from '@angular/forms';

export function quantityValidator(quantity: number) {
    return (control: FormControl) => {
      if(control==undefined){
        return null;
      }
      const enteredQuantity = +control.value;
      if (enteredQuantity !== quantity) {
        return { invalidQuantity: true };
      }
      return null;
    };
  }