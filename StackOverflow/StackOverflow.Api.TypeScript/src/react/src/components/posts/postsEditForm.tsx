import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PostsMapper from './postsMapper';
import PostsViewModel from './postsViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert, TimePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { ToLowerCaseFirstLetter } from '../../lib/stringUtilities';
import { UsersSelectComponent } from '../shared/usersSelect'
	import { PostsSelectComponent } from '../shared/postsSelect'
	import { PostTypesSelectComponent } from '../shared/postTypesSelect'
	interface PostsEditComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface PostsEditComponentState {
  model?: PostsViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
  submitting:boolean;
}

class PostsEditComponent extends React.Component<
  PostsEditComponentProps,
  PostsEditComponentState
> {
  state = {
    model: new PostsViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
	submitted:false,
	submitting:false
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
          let response = resp.data as Api.PostsClientResponseModel;

          console.log(response);

          let mapper = new PostsMapper();

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
	 this.setState({...this.state, submitting:true, submitted:false});
     this.props.form.validateFields((err:any, values:any) => {
     if (!err) {
        let model = values as PostsViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      } 
	  else {
		  this.setState({...this.state, submitting:false, submitted:false});
	  }
    });
  };

  submit = (model:PostsViewModel) =>
  {  
    let mapper = new PostsMapper();
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
            Api.PostsClientRequestModel
          >;
          this.setState({...this.state, submitted:true, submitting:false, model:mapper.mapApiResponseToViewModel(response.record!), errorOccurred:false, errorMessage:''});
          console.log(response);
        },
        error => {
          console.log(error);
		  let errorResponse = error.response.data as ActionResponse; 
		  if(error.response.data)
          {
			  errorResponse.validationErrors.forEach(x =>
			  {
				this.props.form.setFields({
				 [ToLowerCaseFirstLetter(x.propertyName)]: {
				  value:this.props.form.getFieldValue(ToLowerCaseFirstLetter(x.propertyName)),
				  errors: [new Error(x.errorMessage)]
				},
				})
			  });
		  }
          this.setState({...this.state, submitted:true, submitting:false, errorOccurred:true, errorMessage:'Error from API'});
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
              <label htmlFor='acceptedAnswerId'>Accepted Answer</label>
              <br />             
              {getFieldDecorator('acceptedAnswerId', {
              rules:[],
              
              })
              ( <Input placeholder={"Accepted Answer"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='answerCount'>Answer Count</label>
              <br />             
              {getFieldDecorator('answerCount', {
              rules:[],
              
              })
              ( <InputNumber placeholder={"Answer Count"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='body'>Body</label>
              <br />             
              {getFieldDecorator('body', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"Body"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='closedDate'>Closed Date</label>
              <br />             
              {getFieldDecorator('closedDate', {
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"Closed Date"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='commentCount'>Comment Count</label>
              <br />             
              {getFieldDecorator('commentCount', {
              rules:[],
              
              })
              ( <InputNumber placeholder={"Comment Count"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='communityOwnedDate'>Community Owned Date</label>
              <br />             
              {getFieldDecorator('communityOwnedDate', {
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"Community Owned Date"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='creationDate'>Creation Date</label>
              <br />             
              {getFieldDecorator('creationDate', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"Creation Date"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='favoriteCount'>Favorite Count</label>
              <br />             
              {getFieldDecorator('favoriteCount', {
              rules:[],
              
              })
              ( <InputNumber placeholder={"Favorite Count"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='lastActivityDate'>Last Activity Date</label>
              <br />             
              {getFieldDecorator('lastActivityDate', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"Last Activity Date"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='lastEditDate'>Last Edit Date</label>
              <br />             
              {getFieldDecorator('lastEditDate', {
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"Last Edit Date"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='lastEditorDisplayName'>Last Editor Display Name</label>
              <br />             
              {getFieldDecorator('lastEditorDisplayName', {
              rules:[{ max: 40, message: 'Exceeds max length of 40' },
],
              
              })
              ( <Input placeholder={"Last Editor Display Name"} /> )}
              </Form.Item>

						
                        <Form.Item>
                        <label htmlFor='lastEditorUserId'>Last Editor User</label>
                        <br />   
                        <UsersSelectComponent   
                          apiRoute={
                          Constants.ApiEndpoint +
                          ApiRoutes.Users}
                          getFieldDecorator={this.props.form.getFieldDecorator}
                          propertyName="lastEditorUserId"
                          required={false}
                          selectedValue={this.state.model!.lastEditorUserId}
                         />
                        </Form.Item>

						
                        <Form.Item>
                        <label htmlFor='ownerUserId'>Owner User</label>
                        <br />   
                        <UsersSelectComponent   
                          apiRoute={
                          Constants.ApiEndpoint +
                          ApiRoutes.Users}
                          getFieldDecorator={this.props.form.getFieldDecorator}
                          propertyName="ownerUserId"
                          required={false}
                          selectedValue={this.state.model!.ownerUserId}
                         />
                        </Form.Item>

						
                        <Form.Item>
                        <label htmlFor='parentId'>Parent</label>
                        <br />   
                        <PostsSelectComponent   
                          apiRoute={
                          Constants.ApiEndpoint +
                          ApiRoutes.Posts}
                          getFieldDecorator={this.props.form.getFieldDecorator}
                          propertyName="parentId"
                          required={false}
                          selectedValue={this.state.model!.parentId}
                         />
                        </Form.Item>

						
                        <Form.Item>
                        <label htmlFor='postTypeId'>Post Type</label>
                        <br />   
                        <PostTypesSelectComponent   
                          apiRoute={
                          Constants.ApiEndpoint +
                          ApiRoutes.PostTypes}
                          getFieldDecorator={this.props.form.getFieldDecorator}
                          propertyName="postTypeId"
                          required={true}
                          selectedValue={this.state.model!.postTypeId}
                         />
                        </Form.Item>

						<Form.Item>
              <label htmlFor='score'>Score</label>
              <br />             
              {getFieldDecorator('score', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <InputNumber placeholder={"Score"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='tag'>Tag</label>
              <br />             
              {getFieldDecorator('tag', {
              rules:[{ max: 150, message: 'Exceeds max length of 150' },
],
              
              })
              ( <Input placeholder={"Tag"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='title'>Title</label>
              <br />             
              {getFieldDecorator('title', {
              rules:[{ max: 250, message: 'Exceeds max length of 250' },
],
              
              })
              ( <Input placeholder={"Title"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='viewCount'>View Count</label>
              <br />             
              {getFieldDecorator('viewCount', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <InputNumber placeholder={"View Count"} /> )}
              </Form.Item>

			
            <Form.Item>
             <Button type="primary" htmlType="submit" loading={this.state.submitting} >
                {(this.state.submitting ? "Submitting..." : "Submit")}
              </Button>
            </Form.Item>
			{message}
        </Form>);
    } else {
      return null;
    }
  }
}

export const WrappedPostsEditComponent = Form.create({ name: 'Posts Edit' })(PostsEditComponent);

/*<Codenesium>
    <Hash>342c5b8c58d943e6a48e3e25b1514e34</Hash>
</Codenesium>*/