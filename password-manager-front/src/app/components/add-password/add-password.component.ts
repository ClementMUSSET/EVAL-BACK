import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators} from '@angular/forms';
import { ApplicationService } from 'src/app/services/application.service';

@Component({
  selector: 'app-add-password',
  templateUrl: './add-password.component.html',
  styleUrls: ['./add-password.component.scss'],
})
export class AddPasswordComponent implements OnInit {
  passwordForm!: FormGroup;
  applications: any[] = [];

  constructor(private fb: FormBuilder, private appService: ApplicationService) {}

  ngOnInit() {
    this.passwordForm = this.fb.group({
      accountName: ['', [Validators.required, Validators.minLength(3)]],
      applicationId: ['', Validators.required],
      type: ['Grand public', Validators.required],
      password: ['', [Validators.required, Validators.minLength(6)]]
    });

    this.appService.getApplications().subscribe({
      next: (apps) => this.applications = apps,
      error: (err) => console.error("Erreur de chargement des applications", err)
    });
  }

  onSubmit() {
    if (this.passwordForm.valid) {
      console.log('Form Data:', this.passwordForm.value);
      // Envoyer les données au backend
    } else {
      console.log('Formulaire invalide');
    }
  }
}
