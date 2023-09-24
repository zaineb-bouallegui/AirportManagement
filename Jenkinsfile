pipeline {
    agent any // Spécifie l'agent sur lequel le pipeline sera exécuté (n'importe quel agent disponible).

    stages {
        stage('Checkout') {
            steps {
                // Étape pour récupérer le code source du référentiel Git
                checkout scm
            }
        }

        stage('Build') {
            steps {
                // Étape pour construire votre projet .NET
                bat 'dotnet build' // Exemple de commande de construction
            }
        }

        stage('Test') {
            steps {
                // Étape pour exécuter des tests sur votre projet .NET
                bat 'dotnet test' // Exemple de commande de test
            }
        }

        stage('Publish') {
            steps {
                // Étape pour publier votre projet .NET (par exemple, création d'un package)
                bat 'dotnet publish' // Exemple de commande de publication
            }
        }
    }

    post {
        success {
            // Étape exécutée en cas de succès du pipeline
            echo 'Le pipeline a réussi !'
        }

        failure {
            // Étape exécutée en cas d'échec du pipeline
            echo 'Le pipeline a échoué.'
        }
    }
}
