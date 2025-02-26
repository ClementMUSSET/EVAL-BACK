import { Component, OnInit } from '@angular/core';
import { PasswordService } from 'src/app/services/password.service';

@Component({
  selector: 'app-password-list',
  templateUrl: './password-list.component.html',
  styleUrls: ['./password-list.component.scss'],
})
export class PasswordListComponent implements OnInit {
  passwords: any[] = [];

  constructor(private passwordService: PasswordService) {}

  ngOnInit(): void {
    // Appel à l'API pour récupérer les mots de passe
    this.passwordService.getPasswords().subscribe(
      (data) => {
        this.passwords = data;
      },
      (error) => {
        console.error('Erreur lors de la récupération des mots de passe', error);
      }
    );
  }

  // Méthode pour supprimer un mot de passe
  onDelete(id: number): void {
    this.passwordService.deletePassword(id).subscribe(
      () => {
        console.log('Mot de passe supprimé avec succès');
        this.passwords = this.passwords.filter((password) => password.id !== id);
      },
      (error) => {
        console.error('Erreur lors de la suppression du mot de passe', error);
      }
    );
  }
}
