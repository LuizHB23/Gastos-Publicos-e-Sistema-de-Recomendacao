from recomendacao import recomendacao
import requests
import pandas as pd

print('Escolha o usuario digitando o seu id:')
valor = input()

try:
    text = requests.get(f'http://localhost:5163/usuario/{valor}')

    usuario = pd.read_json(text.text, encoding='UTF-8')

    avaliacao = pd.json_normalize(usuario['avaliacao'])

    usuario = usuario.join(avaliacao, how='left')
    usuario.drop('avaliacao', axis=1, inplace=True)
    usuario = usuario[['id', 'filmeId', 'nota', 'idade', 'genero']]
    usuario['genero'] = usuario['genero'].replace({'M': 1, 'F': 0})

    colunas = ['user id', 'item id', 'rating', 'age', 'gender']
    usuario.columns = colunas

    filmes = recomendacao(usuario)
    filmes = filmes['movie title'].values

    print('\nRecomendação de filmes:')
    print(f'1- {filmes[0]}')
    print(f'2- {filmes[1]}')
    print(f'3- {filmes[2]}')
    print(f'4- {filmes[3]}')
    print(f'5- {filmes[4]}\n')

except:
    print('Usuario não existe, programa encerrado.')