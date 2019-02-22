import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import CommentMapper from './commentMapper';
import CommentViewModel from './commentViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert, TimePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface CommentEditComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface CommentEditComponentState {
  model?: CommentViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
}

class CommentEditComponent extends React.Component<
  CommentEditComponentProps,
  CommentEditComponentState
> {
  state = {
    model: new CommentViewModel(),
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
          ApiRoutes.Comments +
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
          let response = resp.data as Api.CommentClientResponseModel;

          console.log(response);

          let mapper = new CommentMapper();

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
        let model = values as CommentViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model:CommentViewModel) =>
  {  
    let mapper = new CommentMapper();
     axios
      .put(
        Constants.ApiEndpoint + ApiRoutes.Comments + '/' + this.state.model!.id,
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
            Api.CommentClientRequestModel
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
              <label htmlFor='creationDate'>CreationDate</label>
              <br />             
              {getFieldDecorator('creationDate', {
              rules:[{ required: true, message: 'Required' },
{ whitespace: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"CreationDate"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='postId'>PostId</label>
              <br />             
              {getFieldDecorator('postId', {
              rules:[{ required: true, message: 'Required' },
{ whitespace: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"PostId"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='score'>Score</label>
              <br />             
              {getFieldDecorator('score', {
              rules:[],
              
              })
              ( <Input placeholder={"Score"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='text'>Text</label>
              <br />             
              {getFieldDecorator('text', {
              rules:[{ required: true, message: 'Required' },
{ whitespace: true, message: 'Required' },
{ max: 700, message: 'Exceeds max length of 700' },
],
              
              })
              ( <Input placeholder={"Text"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='userId'>UserId</label>
              <br />             
              {getFieldDecorator('userId', {
              rules:[],
              
              })
              ( <Input placeholder={"UserId"} /> )}
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

export const WrappedCommentEditComponent = Form.create({ name: 'Comment Edit' })(CommentEditComponent);

/*<Codenesium>
    <Hash>c1da41221445be68df2675de3ff2428b</Hash>
</Codenesium>*/