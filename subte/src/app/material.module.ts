import { ngModuleJitUrl } from "@angular/compiler";
import { NgModule } from "@angular/core";
import {MatToolbarModule} from "@angular/material/toolbar"
import {MatIconModule} from '@angular/material/icon';
import {MatCardModule} from '@angular/material/card';
import {MatButtonModule} from '@angular/material/button';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatRadioModule} from '@angular/material/radio';
import {MatInputModule} from '@angular/material/input';
import {MatSelectModule} from '@angular/material/select';
import {MatExpansionModule} from '@angular/material/expansion';
import {MatTableModule} from '@angular/material/table';

@NgModule({
    exports: [
        MatToolbarModule,
        MatIconModule,
        MatCardModule,
        MatButtonModule,
        MatFormFieldModule,
        MatRadioModule,
        MatInputModule,
        MatSelectModule,
        MatExpansionModule,
        MatTableModule
    ]
})

export class MaterialModule {}