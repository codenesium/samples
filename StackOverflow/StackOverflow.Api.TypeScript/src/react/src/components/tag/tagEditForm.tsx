import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import TagMapper from './tagMapper';
import TagViewModel from './tagViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface TagEditComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface TagEditComponentState {
  model?: TagViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
}

class TagEditComponent extends React.Component<
  TagEditComponentProps,
  TagEditComponentState
> {
  state = {
    model: new TagViewModel(),
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
          ApiRoutes.Tags +
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
          let response = resp.data as Api.TagClientResponseModel;

          console.log(response);

          let mapper = new TagMapper();

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
        let model = values as TagViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model:TagViewModel) =>
  {  
    let mapper = new TagMapper();
     axios
      .put(
        Constants.ApiEndpoint + ApiRoutes.Tags + '/' + this.state.model!.id,
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
            Api.TagClientRequestModel
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
              <label htmlFor='count'>Count</label>
              <br />             
              {getFieldDecorator('count', {
              rules:[],
              
              })
              ( <Input placeholder={"Count"} id={"count"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='excerptPostId'>ExcerptPostId</label>
              <br />             
              {getFieldDecorator('excerptPostId', {
              rules:[],
              
              })
              ( <Input placeholder={"ExcerptPostId"} id={"excerptPostId"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='tagName'>TagName</label>
              <br />             
              {getFieldDecorator('tagName', {
              rules:[],
              
              })
              ( <Input placeholder={"TagName"} id={"tagName"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='wikiPostId'>WikiPostId</label>
              <br />             
              {getFieldDecorator('wikiPostId', {
              rules:[],
              
              })
              ( <Input placeholder={"WikiPostId"} id={"wikiPostId"} /> )}
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

export const WrappedTagEditComponent = Form.create({ name: 'Tag Edit' })(TagEditComponent);

/*<Codenesium>
    <Hash>bd25cd7f09666a54bcd2d87d35e8e12a</Hash>
</Codenesium>*/