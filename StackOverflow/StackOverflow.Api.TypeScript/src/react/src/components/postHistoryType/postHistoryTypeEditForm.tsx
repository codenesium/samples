import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PostHistoryTypeMapper from './postHistoryTypeMapper';
import PostHistoryTypeViewModel from './postHistoryTypeViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert, TimePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface PostHistoryTypeEditComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface PostHistoryTypeEditComponentState {
  model?: PostHistoryTypeViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
}

class PostHistoryTypeEditComponent extends React.Component<
  PostHistoryTypeEditComponentProps,
  PostHistoryTypeEditComponentState
> {
  state = {
    model: new PostHistoryTypeViewModel(),
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
          ApiRoutes.PostHistoryTypes +
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
          let response = resp.data as Api.PostHistoryTypeClientResponseModel;

          console.log(response);

          let mapper = new PostHistoryTypeMapper();

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
        let model = values as PostHistoryTypeViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model:PostHistoryTypeViewModel) =>
  {  
    let mapper = new PostHistoryTypeMapper();
     axios
      .put(
        Constants.ApiEndpoint + ApiRoutes.PostHistoryTypes + '/' + this.state.model!.id,
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
            Api.PostHistoryTypeClientRequestModel
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
              <label htmlFor='rwType'>Type</label>
              <br />             
              {getFieldDecorator('rwType', {
              rules:[{ required: true, message: 'Required' },
{ whitespace: true, message: 'Required' },
{ max: 50, message: 'Exceeds max length of 50' },
],
              
              })
              ( <Input placeholder={"Type"} /> )}
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

export const WrappedPostHistoryTypeEditComponent = Form.create({ name: 'PostHistoryType Edit' })(PostHistoryTypeEditComponent);

/*<Codenesium>
    <Hash>5a39376013124de76e6da4cfa235dbd4</Hash>
</Codenesium>*/