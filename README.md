# Gorilla
大猩猩

# ChatGPT 猩猩版


### Docker
1. clone repo
```
git clone --depth 1 https://github.com/LonelyYeezhiChicken/Gorilla.git
```

2. 
```
cd Gorilla\src\API
```

3. build image
```
 docker build -t gorilla-gpt:tag .
```

4. run in container
```
docker run -p 1599:80 -e API_KEY=<your_gpt_key> --name my-gorilla-container gorilla-gpt:tag
```