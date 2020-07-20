# UnityOutLine-2D
# 利用Shader来实现Sprite和Image的Outline效果

* 只需在SpriteRenderer上绑定SpriteOutline组件，即可实现Outline效果

  * OutlineSize控制厚度
  
  * Color1控制一种颜色
  * Color2控制另一个颜色 

## 使用限制

* Sprite MeshType 必须为FullRect
* Sprite的图片四周留一定的空白。否则生成的SpriteRenderMesh将没有足够的空间用于渲染Outline
* Outline的厚度无法超过Sprite最细的部分

# 使用demo时候 运行Test场景 激活SpriteOutline或者ImageOutline 脚本可以查看测试效果 改变颜色可以替换为自己想要的颜色
