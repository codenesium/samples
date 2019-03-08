import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PostHistoryMapper from './postHistoryMapper';
import PostHistoryViewModel from './postHistoryViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert, TimePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { ToLowerCaseFirstLetter } from '../../lib/stringUtilities';
import { PostHistoryTypesSelectComponent } from '../shared/postHistoryTypesSelect'
	import { PostsSelectComponent } from '../shared/postsSelect'
	import { UsersSelectComponent } from '../shared/usersSelect'
	interface PostHistoryEditComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface PostHistoryEditComponentState {
  model?: PostHistoryViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
  submitting:boolean;
}

class PostHistoryEditComponent extends React.Component<
  PostHistoryEditComponentProps,
  PostHistoryEditComponentState
> {
  state = {
    model: new PostHistoryViewModel(),
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
          ApiRoutes.PostHistory +
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
          let response = resp.data as Api.PostHistoryClientResponseModel;

          console.log(response);

          let mapper = new PostHistoryMapper();

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
        let model = values as PostHistoryViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      } 
	  else {
		  this.setState({...this.state, submitting:false, submitted:false});
	  }
    });
  };

  submit = (model:PostHistoryViewModel) =>
  {  
    let mapper = new PostHistoryMapper();
     axios
      .put(
        Constants.ApiEndpoint + ApiRoutes.PostHistory + '/' + this.state.model!.id,
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
            Api.PostHistoryClientRequestModel
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
              <label htmlFor='comment'>Comment</label>
              <br />             
              {getFieldDecorator('comment', {
              rules:[{ max: 1073741823, message: 'Exceeds max length of 1073741823' },
],
              
              })
              ( <Input placeholder={"Comment"} /> )}
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
                        <label htmlFor='postHistoryTypeId'>Post History Type</label>
                        <br />   
                        <PostHistoryTypesSelectComponent   
                          apiRoute={
                          Constants.ApiEndpoint +
                          ApiRoutes.PostHistoryTypes}
                          getFieldDecorator={this.props.form.getFieldDecorator}
                          propertyName="postHistoryTypeId"
                          required={true}
                          selectedValue={this.state.model!.postHistoryTypeId}
                         />
                        </Form.Item>

						
                        <Form.Item>
                        <label htmlFor='postId'>Post</label>
                        <br />   
                        <PostsSelectComponent   
                          apiRoute={
                          Constants.ApiEndpoint +
                          ApiRoutes.Posts}
                          getFieldDecorator={this.props.form.getFieldDecorator}
                          propertyName="postId"
                          required={true}
                          selectedValue={this.state.model!.postId}
                         />
                        </Form.Item>

						<Form.Item>
              <label htmlFor='revisionGUID'>Revision GUID</label>
              <br />             
              {getFieldDecorator('revisionGUID', {
              rules:[{ required: true, message: 'Required' },
{ max: 36, message: 'Exceeds max length of 36' },
],
              
              })
              ( <Input placeholder={"Revision GUID"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='text'>Text</label>
              <br />             
              {getFieldDecorator('text', {
              rules:[{ max: 1073741823, message: 'Exceeds max length of 1073741823' },
],
              
              })
              ( <Input placeholder={"Text"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='userDisplayName'>User Display Name</label>
              <br />             
              {getFieldDecorator('userDisplayName', {
              rules:[{ max: 40, message: 'Exceeds max length of 40' },
],
              
              })
              ( <Input placeholder={"User Display Name"} /> )}
              </Form.Item>

						
                        <Form.Item>
                        <label htmlFor='userId'>User</label>
                        <br />   
                        <UsersSelectComponent   
                          apiRoute={
                          Constants.ApiEndpoint +
                          ApiRoutes.Users}
                          getFieldDecorator={this.props.form.getFieldDecorator}
                          propertyName="userId"
                          required={false}
                          selectedValue={this.state.model!.userId}
                         />
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

export const WrappedPostHistoryEditComponent = Form.create({ name: 'PostHistory Edit' })(PostHistoryEditComponent);

/*<Codenesium>
    <Hash>4146ba29846625904789cc12493c01c6</Hash>
</Codenesium>*/