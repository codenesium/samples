import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PostMapper from './postMapper';
import PostViewModel from './postViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface PostEditComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface PostEditComponentState {
  model?: PostViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
}

class PostEditComponent extends React.Component<
  PostEditComponentProps,
  PostEditComponentState
> {
  state = {
    model: new PostViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
	submitted:false
  };

    componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Posts +
          '/' +
          this.props.match.params.id,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.PostClientResponseModel;

          console.log(response);

          let mapper = new PostMapper();

          this.setState({
            model: mapper.mapApiResponseToViewModel(response),
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });

		  this.props.form.setFieldsValue(mapper.mapApiResponseToViewModel(response));
        },
        error => {
          console.log(error);
          this.setState({
            model: undefined,
            loading: false,
            loaded: false,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
 }
 
 handleSubmit = (e:FormEvent<HTMLFormElement>) => {
     e.preventDefault();
     this.props.form.validateFields((err:any, values:any) => {
      if (!err) {
        let model = values as PostViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model:PostViewModel) =>
  {  
    let mapper = new PostMapper();
     axios
      .put(
        Constants.ApiEndpoint + ApiRoutes.Posts + '/' + this.state.model!.id,
        mapper.mapViewModelToApiRequest(model),
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as CreateResponse<
            Api.PostClientRequestModel
          >;
          this.setState({...this.state, submitted:true, model:mapper.mapApiResponseToViewModel(response.record!), errorOccurred:false, errorMessage:''});
          console.log(response);
        },
        error => {
          console.log(error);
          this.setState({...this.state, submitted:true, errorOccurred:true, errorMessage:'Error from API'});
        }
      ); 
  }
  
  render() {

    const { getFieldDecorator, getFieldsError, getFieldError, isFieldTouched } = this.props.form;
        
    let message:JSX.Element = <div></div>;
    if(this.state.submitted)
    {
      if (this.state.errorOccurred) {
        message = <Alert message={this.state.errorMessage} type='error' />;
      }
      else
      {
        message = <Alert message='Submitted' type='success' />;
      }
    }

    if (this.state.loading) {
      return <Spin size="large" />;
    } 
    else if (this.state.loaded) {

        return ( 
         <Form onSubmit={this.handleSubmit}>
            			<Form.Item>
              <label htmlFor='acceptedAnswerId'>AcceptedAnswerId</label>
              <br />             
              {getFieldDecorator('acceptedAnswerId', {
              rules:[],
              
              })
              ( <Input placeholder={"AcceptedAnswerId"} id={"acceptedAnswerId"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='answerCount'>AnswerCount</label>
              <br />             
              {getFieldDecorator('answerCount', {
              rules:[],
              
              })
              ( <Input placeholder={"AnswerCount"} id={"answerCount"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='body'>Body</label>
              <br />             
              {getFieldDecorator('body', {
              rules:[],
              
              })
              ( <Input placeholder={"Body"} id={"body"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='closedDate'>ClosedDate</label>
              <br />             
              {getFieldDecorator('closedDate', {
              rules:[],
              
              })
              ( <Input placeholder={"ClosedDate"} id={"closedDate"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='commentCount'>CommentCount</label>
              <br />             
              {getFieldDecorator('commentCount', {
              rules:[],
              
              })
              ( <Input placeholder={"CommentCount"} id={"commentCount"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='communityOwnedDate'>CommunityOwnedDate</label>
              <br />             
              {getFieldDecorator('communityOwnedDate', {
              rules:[],
              
              })
              ( <Input placeholder={"CommunityOwnedDate"} id={"communityOwnedDate"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='creationDate'>CreationDate</label>
              <br />             
              {getFieldDecorator('creationDate', {
              rules:[],
              
              })
              ( <Input placeholder={"CreationDate"} id={"creationDate"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='favoriteCount'>FavoriteCount</label>
              <br />             
              {getFieldDecorator('favoriteCount', {
              rules:[],
              
              })
              ( <Input placeholder={"FavoriteCount"} id={"favoriteCount"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='lastActivityDate'>LastActivityDate</label>
              <br />             
              {getFieldDecorator('lastActivityDate', {
              rules:[],
              
              })
              ( <Input placeholder={"LastActivityDate"} id={"lastActivityDate"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='lastEditDate'>LastEditDate</label>
              <br />             
              {getFieldDecorator('lastEditDate', {
              rules:[],
              
              })
              ( <Input placeholder={"LastEditDate"} id={"lastEditDate"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='lastEditorDisplayName'>LastEditorDisplayName</label>
              <br />             
              {getFieldDecorator('lastEditorDisplayName', {
              rules:[],
              
              })
              ( <Input placeholder={"LastEditorDisplayName"} id={"lastEditorDisplayName"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='lastEditorUserId'>LastEditorUserId</label>
              <br />             
              {getFieldDecorator('lastEditorUserId', {
              rules:[],
              
              })
              ( <Input placeholder={"LastEditorUserId"} id={"lastEditorUserId"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='ownerUserId'>OwnerUserId</label>
              <br />             
              {getFieldDecorator('ownerUserId', {
              rules:[],
              
              })
              ( <Input placeholder={"OwnerUserId"} id={"ownerUserId"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='parentId'>ParentId</label>
              <br />             
              {getFieldDecorator('parentId', {
              rules:[],
              
              })
              ( <Input placeholder={"ParentId"} id={"parentId"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='postTypeId'>PostTypeId</label>
              <br />             
              {getFieldDecorator('postTypeId', {
              rules:[],
              
              })
              ( <Input placeholder={"PostTypeId"} id={"postTypeId"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='score'>Score</label>
              <br />             
              {getFieldDecorator('score', {
              rules:[],
              
              })
              ( <Input placeholder={"Score"} id={"score"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='tag'>Tags</label>
              <br />             
              {getFieldDecorator('tag', {
              rules:[],
              
              })
              ( <Input placeholder={"Tags"} id={"tag"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='title'>Title</label>
              <br />             
              {getFieldDecorator('title', {
              rules:[],
              
              })
              ( <Input placeholder={"Title"} id={"title"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='viewCount'>ViewCount</label>
              <br />             
              {getFieldDecorator('viewCount', {
              rules:[],
              
              })
              ( <Input placeholder={"ViewCount"} id={"viewCount"} /> )}
              </Form.Item>

			
          <Form.Item>
            <Button type="primary" htmlType="submit">
                Submit
              </Button>
            </Form.Item>
			{message}
        </Form>);
    } else {
      return null;
    }
  }
}

export const WrappedPostEditComponent = Form.create({ name: 'Post Edit' })(PostEditComponent);

/*<Codenesium>
    <Hash>a0bbd4eb31484194cd71635bf7f5d81e</Hash>
</Codenesium>*/