

\CRM_App>ng new ClientApp

\ClientApp>npm install --save @angular/material @angular/cdk @angular/core @angular/common

\ClientApp>ng g class models/citizen

ng g c components/nav/nav --module=app.module.ts
ng g c components/citizen/citizen --module=app.module.ts
ng g c components/citizen/citizen --module=app.module.ts

ng g c components/foreas/foreaslist --module=app.module.ts


ng g c components/foreas/foreas --module=app.module.ts

ng g service services/foreas 

ng g service services/auth 

ng g guard guards/auth

Activate all three interfaces
